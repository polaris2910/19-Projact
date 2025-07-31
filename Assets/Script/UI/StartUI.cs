using Microsoft.VisualBasic;
using System;
using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartUI : BaseUI
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);
        //startButton.onClick.AddListener(OnClickStartButton);
        //exitButton.onClick.AddListener(OnClickExitButton);
    }

    public void OnClickStartButton()
    {
        // Start 버튼 누르면 UI 끄고 게임 시작 로직 수행
        gameObject.SetActive(false);
        GameManager.Instance.StartGame(); // 예시: GameManager에 StartGame() 만들어서 연결
    }

    public void OnClickExitButton()
    {
        Application.Quit();
    }

    protected override UIState GetUIState()
    {
        return UIState.Start;
    }
}