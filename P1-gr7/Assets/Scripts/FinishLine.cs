using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player crossed the finish line!");
            FindObjectOfType<scoreManager>().ShowWinScreen(); // Show the Win Screen
        }
    }
}
