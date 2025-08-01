using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void ExitButton()
    {
        Debug.Log("Exit 버튼이 눌렸습니다.");
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}