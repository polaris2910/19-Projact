using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : BaseUI
{
    [SerializeField] Button retryButton;
    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);
        retryButton.onClick.AddListener(Retry);
    }
    protected override UIState GetUIState()
    {
        return UIState.GameOver;
    }

    private void Retry()
    {
        GameManager.Instance.RestartGame();
    }
    
    
}
