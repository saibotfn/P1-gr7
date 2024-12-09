using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public GhostHolder ghostHolder;
    //If working on implementing ghost play on 2 levels: Create two ghostHolders

    private void NewRecord() //Displays new record time
    {
        Debug.Log($"NEW RECORD! Time is {ghostHolder.timeStamp[^1]} !");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player crossed the finish line!");
            scoreManager.instance.ShowWinScreen(); // Show the Win Screen

            if(ghostHolder.recordTimeStamp.Count == 0) //If no record time yet, add the new time as record
            {
                ghostHolder.UpdateRecord();
                NewRecord();
            }
            else if (ghostHolder.timeStamp[^1] < ghostHolder.recordTimeStamp[^1]) //Updates the record for the ghost player if new run time is better than old record
            {
                ghostHolder.UpdateRecord();
                NewRecord();
            }
        }
    }
}
