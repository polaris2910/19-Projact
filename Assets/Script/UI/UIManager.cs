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
    public CanvasGroup achievementImageGroup;


    [SerializeField] private Slider healthBar;
    
   
    
    private ScoreUI scoreUI;
    private StartUI startUI;
    private SettingsUI settingsUI;
    private GameOverUI gameOverUI;
    

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
        startUI = GetComponentInChildren<StartUI>(true);
        startUI.Init(this);
        settingsUI = GetComponentInChildren<SettingsUI>(true);
        settingsUI.Init(this);
        gameOverUI=GetComponentInChildren<GameOverUI>(true);
        gameOverUI.Init(this);
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
        startUI.SetActiveUI(currentState);
        settingsUI.SetActiveUI(currentState);


    }
    public void ShowAchievementUI()
    {
        StartCoroutine(FadeAchievement());
    }

    private IEnumerator FadeAchievement()
    {
        achievementImageGroup.gameObject.SetActive(true);

        // 페이드 인
        float duration = 1f;
        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            achievementImageGroup.alpha = Mathf.Lerp(0, 1, t / duration);
            yield return null;
        }
        achievementImageGroup.alpha = 1;

        yield return new WaitForSeconds(1.5f); // 이미지가 완전히 보이는 시간

        // 페이드 아웃
        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            achievementImageGroup.alpha = Mathf.Lerp(1, 0, t / duration);
            yield return null;
        }
        achievementImageGroup.alpha = 0;
        achievementImageGroup.gameObject.SetActive(false);
    }
}
