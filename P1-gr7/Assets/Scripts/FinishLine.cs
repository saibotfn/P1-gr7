using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public GhostHolder ghostHolder;
    //Create two ghostHolders


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player crossed the finish line!");
            scoreManager.instance.ShowWinScreen(); // Show the Win Screen
            if(ghostHolder.recordTimeStamp.Count == 0)
            {
                ghostHolder.UpdateRecord();
            }
            else if (ghostHolder.timeStamp[^1] < ghostHolder.recordTimeStamp[^1]) //Updates the record for the ghost player if conditions are met
            {
                ghostHolder.UpdateRecord();
                Debug.Log("NEW RECORD! Time is " + ghostHolder.timeStamp[^1] + "!");
            }
        }
    }
}
