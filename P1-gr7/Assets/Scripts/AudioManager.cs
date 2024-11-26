using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("--------Audio Source-------")]
    [SerializeField] AudioSource SFXSource;
    [SerializeField] AudioSource musicSource;

    [Header("--------Audio Clip-------")]
    public AudioClip CollisionObstacle;
    public AudioClip MainGameMusic;
    public AudioClip MainMenuMusic;
    
    private void Start()
    {
        musicSource.clip = MainGameMusic;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
