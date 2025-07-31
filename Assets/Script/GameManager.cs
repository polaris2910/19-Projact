using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // �ߺ� ����
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
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StartGame()
    {
        Debug.Log("���� ����!");
    }
    public void GameOver()
    {
        Time.timeScale = 0f;
        if (UIManager.Instance != null)
        {
            UIManager.Instance.ChangeState(UIState.GameOver);
        }
        Debug.Log("��-��");
    }
}
