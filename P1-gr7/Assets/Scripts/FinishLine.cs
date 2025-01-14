using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
 // Reference to a GhostHolder object that manages ghost player records and times
public GhostHolder ghostHolder;

// If implementing ghost play on two levels, consider creating two separate ghostHolder instances for each level

// Method to display a new record time
private void NewRecord()
{
    // Logs the latest timestamp as a new record to the console
    Debug.Log($"NEW RECORD! Time is {ghostHolder.timeStamp[^1]} !");
}

// Method triggered when another object enters a 2D trigger collider attached to this object
private void OnTriggerEnter2D(Collider2D other)
{
    // Check if the colliding object has the "Player" tag
    if (other.CompareTag("Player"))
    {
        // Log a message indicating that the player has crossed the finish line
        Debug.Log("Player crossed the finish line!");

        // Pause the game by setting time scale to 0
        Time.timeScale = 0f;

        // Check if a ScoreManager instance exists
        if (scoreManager.instance != null)
        {
            // Show the win screen via the ScoreManager
            scoreManager.instance.ShowWinScreen();
        }

        // Check if a GhostHolder instance is assigned
        if (ghostHolder != null)
        {
            // If there are no record timestamps yet, set the current run time as the new record
            if (ghostHolder.recordTimeStamp.Count == 0)
            {
                ghostHolder.UpdateRecord(); // Update the ghost record
                NewRecord();               // Display the new record
            }
            // If the current run time is better than the previous record, update the record
            else if (ghostHolder.timeStamp[^1] < ghostHolder.recordTimeStamp[^1])
            {
                ghostHolder.UpdateRecord(); // Update the ghost record
                NewRecord();               // Display the new record
            }
        }
    }
}
}
