using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1;

    SFXManager sFXManager;

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
            sFXManager.PlaySFX(sFXManager.CoinPickup); //Spiller lyd, når man samler mønt op

            Destroy(gameObject);

        }
    }

}
