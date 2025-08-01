using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementUI : BaseUI
{
    [SerializeField] CanvasGroup achievementImageGroup;

    protected override UIState GetUIState()
    {
        return UIState.Achievement;
    }

    private void OnEnable()
    {
        Debug.Log("���� ����");
        StartCoroutine(FadeAchievement());
    }




    private IEnumerator FadeAchievement()
    {
        achievementImageGroup.gameObject.SetActive(true);

        // ���̵� ��
        float duration = 1f;
        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            achievementImageGroup.alpha = Mathf.Lerp(0, 1, t / duration);
            yield return null;
        }
        achievementImageGroup.alpha = 1;

        yield return new WaitForSeconds(1.5f); // �̹����� ������ ���̴� �ð�

        // ���̵� �ƿ�
        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            achievementImageGroup.alpha = Mathf.Lerp(1, 0, t / duration);
            yield return null;
        }
        achievementImageGroup.alpha = 0;
        achievementImageGroup.gameObject.SetActive(false);
    }
}
