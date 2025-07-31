using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMmanager : MonoBehaviour
{
    public static BGMmanager instance;

    private AudioSource audioSource;
    void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();

        // 저장된 볼륨이 있다면 불러와서 적용
        if (PlayerPrefs.HasKey("BGMVolume"))
        {
            float savedVolume = PlayerPrefs.GetFloat("BGMVolume");
            audioSource.volume = savedVolume;
        }
    }

    public void SetVolume(float value)
    {
        audioSource.volume = value;

        // 볼륨 저장
        PlayerPrefs.SetFloat("BGMVolume", value);
        PlayerPrefs.Save();
    }
}
