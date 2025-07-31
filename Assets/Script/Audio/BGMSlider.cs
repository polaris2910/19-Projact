using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGMSlider : MonoBehaviour
{
    [SerializeField] private Slider bgmSlider;

    void Start()
    {

        bgmSlider.onValueChanged.AddListener(SetVolume);
    }

    void SetVolume(float value)
    {
        if (BGMmanager.instance != null)
        {
            BGMmanager.instance.SetVolume(value);
        }
    }
}
