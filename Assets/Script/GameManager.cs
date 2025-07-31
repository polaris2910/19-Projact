using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    

    private void Awake()
    {
        // ΩÃ±€≈Ê «“¥Á
        Instance = this;
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GameOver()
    {
        Time.timeScale = 0f;
        UIManager.Instance.ShowGameOverUI();
        Debug.Log("ªÁ-∏¡");
    }
}
