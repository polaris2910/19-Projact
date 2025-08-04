using UnityEngine;

public class Achievements : MonoBehaviour
{
    public ResourceManager resourceManager; // �÷��̾� ü�� ������

    private int obstacleCount = 0;
    private bool achievementUnlocked = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Trigger"))
        {
            if (obstacleCount == 0)
            {
                resourceManager.ResetDamageRecord(); // ó������ ���� ��� �ʱ�ȭ
            }

            obstacleCount++;

            Debug.Log($"��ֹ� ���: {obstacleCount} ");

            if (obstacleCount >= 10 && !achievementUnlocked)
            {
                if (!resourceManager.TookDamageDuringRun)
                {
                    TriggerPerfectRun(); // ���� �޼�
                    achievementUnlocked = true;
                }

                obstacleCount = 0;
                resourceManager.ResetDamageRecord(); // �ʱ�ȭ
            }
        }
    }
    public void ResetObstacleCount()
    {
        obstacleCount = 0;
        Debug.Log($"{obstacleCount}");
    }
    private void TriggerPerfectRun()
    {
        UIManager.Instance.ChangeState(UIState.Achievement);
        //UI, ����, �ִϸ��̼� �� �߰�
    }
}
