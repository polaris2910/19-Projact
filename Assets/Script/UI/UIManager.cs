using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum UIState
{
    Achievement,
    
    Game,
    Settings,
    GameOver,
    Clear

}
public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    


    
    
   
    
    private GameUI gameUI;
    private SettingsUI settingsUI;
    private GameOverUI gameOverUI;
    private AchievementUI achievementUI;
    private ClearUI clearUI;

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

        //homeUI = GetComponentInChildren<HomeUI>();
        //homeUI.Init(this);
        gameUI = GetComponentInChildren<GameUI>(true);
        gameUI.Init(this);
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
        
        ChangeState(UIState.Game); //��Ÿ��ȭ���� ����Ʈ
       
    }
    private void Update()
    {

        

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(currentState!=UIState.Settings)
            {
                ChangeState(UIState.Settings);
            }
            else
            {
                ChangeState(UIState.Game);
                
            }
            
        }
        

    }
    

    
    
   
    public void ChangeState(UIState state) //�̰� �߰�!!
    {
        currentState = state;

        //startUI.SetActive(currentState == UIState.Start);
        gameOverUI.SetActiveUI(currentState);
        gameUI.SetActiveUI(currentState);
        
        settingsUI.SetActiveUI(currentState);
        achievementUI.SetActiveUI(currentState);
        clearUI.SetActiveUI(currentState) ;


    }
    

    
}
