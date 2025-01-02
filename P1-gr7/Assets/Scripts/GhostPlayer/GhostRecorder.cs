using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GhostRecorder : MonoBehaviour
{
    public GhostHolder ghostHolder;


    private float timer;
    private float timeValue;
    playerMovement playerMovement;

    private void Awake()
    {
        playerMovement = FindObjectOfType<playerMovement>(); //Instantiates playerMovement to access bool canMove

        ghostHolder.ResetData();
        timeValue = 0;
        timer = 0;

        ghostHolder.timeStamp.Add(0); //Hardcodes that the lists start at time 0 and position 0
        ghostHolder.position.Add(new Vector2(0, 0));
    }

    private void Update()
    {
        if (playerMovement.canMove)
        {
            timer += Time.unscaledDeltaTime;
            timeValue += Time.unscaledDeltaTime;

            if (timer >= 1 / ghostHolder.recordFrequency) //Adds to the lists ghostHolder.recordFrequency/sec
            {
                ghostHolder.timeStamp.Add(timeValue);
                ghostHolder.position.Add(this.transform.position);
                //ghostHolder.rotation.Add(this.transform.eulerAngles);

                timer = 0;
            }
        }
    }
}