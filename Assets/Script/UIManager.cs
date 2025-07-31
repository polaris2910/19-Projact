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


    private UIState currentState; // 이거 추가!

    private bool isSettingsOpen = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);  // 중복 방지
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
        
        ChangeState(UIState.Start); //스타팅화면이 디폴트
       
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
    public void ChangeState(UIState state) //이거 추가!!
    {
        currentState = state;

        //startUI.SetActive(currentState == UIState.Start);
        //gameOverUI.SetActive(currentState==UIState.GameOver);
        scoreUI.SetActiveUI(currentState);
        startUI.SetActiveUI(currentState);
        settingsUI.SetActiveUI(currentState);


    }

}
