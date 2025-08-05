using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{

    
    public static StageManager Instance;

    public Stage currentStage;

    public Action<Stage> OnStageChange;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Debug.Log("스테이지매니저 인스턴스");
        }
        
    }


    
    public void SetStage(Stage stage)
    {
        if(currentStage!=stage)
        {
            OnStageChange?.Invoke(stage);
        }
        currentStage = stage;
        

    }
}



public enum Stage
{
    Stage_1,
    Stage_2
}