using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1;

    SFXManager sFXManager;
    public AudioClip coinSound;
    
    public AudioSource audioSource;

    private void Awake()
    {
        sFXManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<SFXManager>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player touched a coin");
            scoreManager.instance.addScore(coinValue);

            Destroy(gameObject);

            audioSource.GetComponent<AudioSource>().PlayOneShot(coinSound);


           // sFXManager.PlaySFX(sFXManager.CoinPickup); //Spiller lyd, n�r man samler m�nt op

        }
    }

}
