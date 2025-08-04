using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        
    }

    public Stage SetStage(Stage stage)
    {
        return stage;
    }
}

public enum Stage
{
    Stage_1,
    Stage_2
}