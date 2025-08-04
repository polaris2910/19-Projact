using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] ObstacleController obstacleController;
    
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

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.S))
        {
            StartGame();
        }
    }
    public void RestartGame()
    {
        ResourceManager.Instance.SetScore(0);
        ResourceManager.Instance.SetHealth(3f);
        Time.timeScale = 1f;
        UIManager.Instance.ChangeState(UIState.Game);
        
        obstacleController.SetData();
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }
    public void StartGame()
    {
        ResourceManager.Instance.SetScore(0);
        ResourceManager.Instance.SetHealth(3f);

        Time.timeScale = 1f;
        UIManager.Instance.ChangeState(UIState.Game);
        obstacleController.SetData();
    }
    public void GameOver()
    {
        Time.timeScale = 0f;
        if (UIManager.Instance != null)
        {
            UIManager.Instance.ChangeState(UIState.GameOver);
        }
        Debug.Log("사-망");
    }
}
