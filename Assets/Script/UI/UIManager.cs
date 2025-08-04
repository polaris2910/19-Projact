using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum UIState
{
    Achievement,
    
    Score,
    Settings,
    GameOver,
    Clear

}
public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    


    [SerializeField] private Slider healthBar;
    
   
    
    private ScoreUI scoreUI;
    private SettingsUI settingsUI;
    private GameOverUI gameOverUI;
    private AchievementUI achievementUI;
    private ClearUI clearUI;

    private UIState currentState; // 이거 추가!

  

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
        settingsUI = GetComponentInChildren<SettingsUI>(true);
        settingsUI.Init(this);
        gameOverUI=GetComponentInChildren<GameOverUI>(true);
        gameOverUI.Init(this);
        achievementUI = GetComponentInChildren<AchievementUI>(true);
        achievementUI.Init(this);
        clearUI = GetComponentInChildren<ClearUI>(true);
        clearUI.Init(this);
    }
    private void Start()
    {
        
        ChangeState(UIState.Score); //스타팅화면이 디폴트
       
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
    

    private void HealthBarUpdate()
    {
        float ratio = ResourceManager.Instance.CurrentHealth;
        healthBar.value = ratio;
    }
    
   
    public void ChangeState(UIState state) //이거 추가!!
    {
        currentState = state;

        //startUI.SetActive(currentState == UIState.Start);
        gameOverUI.SetActiveUI(currentState);
        scoreUI.SetActiveUI(currentState);
        
        settingsUI.SetActiveUI(currentState);
        achievementUI.SetActiveUI(currentState);
        clearUI.SetActiveUI(currentState) ;


    }
    

    
}
