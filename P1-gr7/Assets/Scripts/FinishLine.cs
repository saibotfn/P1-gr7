using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Check if the player crosses the finish line
        {
            Debug.Log("Player crossed the finish line!");
            // Add your win logic here (e.g., show UI, stop the game)
        }
    }
}
