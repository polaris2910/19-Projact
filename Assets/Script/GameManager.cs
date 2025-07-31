using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public void StartGame()
    {
        Debug.Log("게임 시작!");
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // 중복 방지
            return;
        }
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GameOver()
    {
        Time.timeScale = 0f;
        if (UIManager.Instance != null)
        {
            UIManager.Instance.ShowGameOverUI();
        }
        Debug.Log("사-망");
    }
}
