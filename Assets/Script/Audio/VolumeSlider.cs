using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;

    void Start()
    {
        
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    void SetVolume(float value)
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.SetVolume(value);
        }
    }
}
