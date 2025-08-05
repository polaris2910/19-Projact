using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private AudioSource audioSource;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip HurtSound;
    [SerializeField] private AudioClip DeathSound;
    [SerializeField] private AudioClip EatSound;

    void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
        if (PlayerPrefs.HasKey("Volume"))
        {
            float savedVolume = PlayerPrefs.GetFloat("Volume");
            audioSource.volume = savedVolume;
        }
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

    public void SetVolume(float value)
    {
        audioSource.volume = value;

        // º¼·ý ÀúÀå
        PlayerPrefs.SetFloat("Volume", value);
        PlayerPrefs.Save();
    }

    public void PlayHurtSound()
    {
        PlaySound(HurtSound);
    }
    public void PlayDeathSound()
    {
        PlaySound(DeathSound);
    }
    public void PlayEatSound()
    {
        PlaySound(EatSound);
    }
}
