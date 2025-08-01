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
        startButton.onClick.AddListener(OnClickStartButton);
        exitButton.onClick.AddListener(OnClickExitButton);
    }

    public void OnClickStartButton()
    {
        // Start ��ư ������ UI ���� ���� ���� ���� ����
        gameObject.SetActive(false);
        GameManager.Instance.StartGame(); // ����: GameManager�� StartGame() ���� ����
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