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


    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private Slider healthBar;
    [SerializeField] private ResourceManager resourceManager;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject startUI;
    private StartUI startUIScreen;
    private bool isSettingsOpen = false;
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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isSettingsOpen = !isSettingsOpen;
            settingsPanel.SetActive(isSettingsOpen);
            PauseGame(isSettingsOpen);
        }
    }
    void PauseGame(bool pause)
    {
        Time.timeScale = pause ? 0f : 1f;
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
