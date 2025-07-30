using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private AudioSource audioSource;
    [SerializeField] private AudioClip jumpSound;
    
    void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }
    public void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
            audioSource.PlayOneShot(clip);
    }
    // Update is called once per frame
    public void PlayJumpSound()
    {
        Debug.Log("Jump sound played: " + jumpSound?.name);
        PlaySound(jumpSound);
    }
}
