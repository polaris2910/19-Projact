using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsUI : BaseUI
{
    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);
        
    }
    protected override UIState GetUIState()
    {
        return UIState.Settings;
    }

    private void OnEnable()
    {
        PauseGame();
    }
    void PauseGame()
    {
        Debug.Log("ȭ���� ����");
        //Time.timeScale = pause ? 0f : 1f;
    }
}
