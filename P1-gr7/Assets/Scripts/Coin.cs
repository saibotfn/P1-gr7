using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1;

    SFXManager sFXManager;
  
    private void Awake()
    {
        sFXManager = FindObjectOfType<SFXManager>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player touched a coin");
            scoreManager.instance.addScore(coinValue);

            if (sFXManager == null)
            {
                Debug.LogError("SFXManager is null.");
            }
            else if (sFXManager.CoinPickup == null)
            {
                Debug.LogError("CoinPickup is null.");
            }
            else
            {
                sFXManager.PlaySFX(sFXManager.CoinPickup);
            }
            Destroy(gameObject);
        }
    }

}
