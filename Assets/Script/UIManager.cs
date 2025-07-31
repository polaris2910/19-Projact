using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum UIState
{
    Start,
    Exit,
    Score,
    Settings,
    GameOver
}
public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }


    //[SerializeField] private GameObject settingsPanel;
    [SerializeField] private Slider healthBar;
    
    //[SerializeField] private GameObject gameOverUI;
    //[SerializeField] private GameObject startUI;
    
    private ScoreUI scoreUI;
    private StartUI startUI;
    private SettingsUI settingsUI;


    private UIState currentState; // �̰� �߰�!

    private bool isSettingsOpen = false;

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

        //homeUI = GetComponentInChildren<HomeUI>();
        //homeUI.Init(this);
        scoreUI = GetComponentInChildren<ScoreUI>(true);
        scoreUI.Init(this);
        startUI = GetComponentInChildren<StartUI>(true);
        startUI.Init(this);
        settingsUI = GetComponentInChildren<SettingsUI>(true);
        settingsUI.Init(this);
        //gameOverUI.GetComponentInChildren<GameOverUI>();
        //gameOverUI.Init(this);
    }
    private void Start()
    {
        
        ChangeState(UIState.Start); //��Ÿ��ȭ���� ����Ʈ
       
    }
    private void Update()
    {

        HealthBarUpdate();

        float ratio = ResourceManager.Instance.CurrentHealth;
        healthBar.value = ratio;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(currentState!=UIState.Settings)
            {
                ChangeState(UIState.Settings);
            }
            else
            {
                ChangeState(UIState.Score);
                
            }
            
        }

    }
    
    public void ShowGameOverUI()
    {
    //    gameOver.SetActive(true);
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

        //startUI.SetActive(currentState == UIState.Start);
        //gameOverUI.SetActive(currentState==UIState.GameOver);
        scoreUI.SetActiveUI(currentState);
        startUI.SetActiveUI(currentState);
        settingsUI.SetActiveUI(currentState);


    }

}
