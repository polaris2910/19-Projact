using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum UIState
{
    Start,
    Exit,
    Score,
    GameOver
}
public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }



    [SerializeField] private Slider healthBar;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject startUI;
    [SerializeField] private GameObject ScoreUI;
    private StartUI startUIScreen;

    private UIState currentState; // �̰� �߰�!
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);  // �ߺ� ����
        }
    }
    private void Start()
    {
        startUIScreen = GetComponentInChildren<StartUI>();
        if (startUIScreen != null)
            startUIScreen.Init(this);

        ChangeState(UIState.Start); //�̰� �ٲ�
    }
    private void Update()
    {
        HealthBarUpdate();
    }

    private void HealthBarUpdate()
    {
        float ratio = ResourceManager.Instance.CurrentHealth;
        healthBar.value = ratio;
    }
    
    //public void ShowGameOverUI()
    //{
    //    gameOverUI.SetActive(true);
    //}

    //public void ShowStartUI()
    //{
    //    startUI.SetActive(true);
    //}
    public void ChangeState(UIState state) //�̰� �߰�!!
    {
        currentState = state;

        startUI.SetActive(currentState == UIState.Start);
        gameOverUI.SetActive(currentState==UIState.GameOver);
        ScoreUI.SetActive(currentState==UIState.Score);

    }

}
