using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{

    
    public static StageManager Instance;

    private Stage currentStage;



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        
    }


    public Action<Stage> OnStageChange;
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