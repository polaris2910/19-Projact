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
        audioSource = GetComponent<AudioSource>(); // ���� GameObject ���� AudioSource
    }
    public void SetVolume(float value)
    {
        audioSource.volume = value;
    }
}
