using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] private Slider healthBar;
    [SerializeField] private ResourceManager resourceManager;
    [SerializeField] private GameObject gameOver;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);  // �ߺ� ����
        }
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
}
