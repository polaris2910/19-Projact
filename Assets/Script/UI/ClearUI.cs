using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearUI : BaseUI
{

    [SerializeField] Button nextStageButton;
    protected override UIState GetUIState()
    {
        return UIState.Clear;
    }
    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);
        nextStageButton.onClick.AddListener(NextStage);
    }
    

    void NextStage()
    {
        StageManager.Instance.SetStage(Stage.Stage_2);
        GameManager.Instance.StartGame();
    }




}
