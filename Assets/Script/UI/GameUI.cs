using System;
using TMPro;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : BaseUI
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text stageText;
    [SerializeField] private Slider healthBar;

    UIManager _uIManager;

    public override void Init(UIManager uiManager)
    {
        _uIManager = uiManager;
        
    }
    protected override UIState GetUIState()
    {
        return UIState.Game;
    }


    private void OnEnable()
    {
        
        StageManager.Instance.OnStageChange += UpdateStageText;

    }

    private void OnDisable()
    {
        StageManager.Instance.OnStageChange -= UpdateStageText;
    }
    private void Update()
    {
        scoreText.text = ResourceManager.Instance.Score.ToString();
        
        HealthBarUpdate();
        
    }

    private void HealthBarUpdate()
    {
        float ratio = ResourceManager.Instance.CurrentHealth;
        if(ResourceManager.Instance==null)
        {
            Debug.Log("RM is null");
        }
       
        healthBar.value = ratio;
    }
    void UpdateStageText(Stage stage)
    {
        if(stage==Stage.Stage_1)
        {
            stageText.text = 1.ToString();
        }
        else if(stage==Stage.Stage_2)
        {
            stageText.text=2.ToString();
        }

    }
}
