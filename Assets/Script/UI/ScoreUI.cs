using System;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private ResourceManager resourceManager;

    private void Update()
    {
        scoreText.text = resourceManager.Score.ToString();
    }
}
