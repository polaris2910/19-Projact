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

        // ����� ������ �ִٸ� �ҷ��ͼ� ����
        if (PlayerPrefs.HasKey("BGMVolume"))
        {
            float savedVolume = PlayerPrefs.GetFloat("BGMVolume");
            audioSource.volume = savedVolume;
        }
    }

    public void SetVolume(float value)
    {
        audioSource.volume = value;

        // ���� ����
        PlayerPrefs.SetFloat("BGMVolume", value);
        PlayerPrefs.Save();
    }
}
