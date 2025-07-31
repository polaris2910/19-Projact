using System;
using TMPro;
using UnityEngine;

public class ScoreUI : BaseUI
{
    [SerializeField] private TMP_Text scoreText;

    protected override UIState GetUIState()
    {
        return UIState.Score;
    }

    private void Update()
    {
        scoreText.text = ResourceManager.Instance.Score.ToString();
    }
}
