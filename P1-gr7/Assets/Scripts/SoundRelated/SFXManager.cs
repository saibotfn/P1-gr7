using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SFXManager : MonoBehaviour
{
    [Header("--------Audio Source-------")]
    [SerializeField] AudioSource SFXSource;
    
    [Header("--------Audio Clip-------")]
    public AudioClip CollisionObstacle;
    public AudioClip CoinPickup;
    public AudioClip BarrierCollision;

    private static SFXManager instance;

    // Makes the gameobject persist between scenes
    private void Awake()
    {
        // Ensure there's only one instance of SFXManager
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Make the GameObject persistent
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}