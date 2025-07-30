using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private ResourceManager resourceManager;

    private void Update()
    {
        float ratio = resourceManager.CurrentHealth;
        healthBar.value = ratio;
    }
}
