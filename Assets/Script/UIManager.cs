using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum UIState
{
    Start,
    Exit,
}
public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }



    [SerializeField] private Slider healthBar;
    [SerializeField] private ResourceManager resourceManager;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject startUI;
    private StartUI startUIScreen;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);  // 중복 방지
        }
    }
    private void Start()
    {
        startUIScreen = startUI.GetComponent<StartUI>();
        if (startUIScreen != null)
            startUIScreen.Init(this);

        ShowStartUI();
    }
    private void Update()
    {
        float ratio = resourceManager.CurrentHealth;
        healthBar.value = ratio;
    }
    public void ShowGameOverUI()
    {
        gameOver.SetActive(true);
    }

    public void ShowStartUI()
    {
        startUI.SetActive(true);
    }
}
