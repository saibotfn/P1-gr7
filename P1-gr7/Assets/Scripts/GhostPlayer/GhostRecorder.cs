using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostRecorder : MonoBehaviour
{
    public GhostHolder ghostHolder;
    //Create ghostHolder for level 1 and 2
    
    private float timer;
    private float timeValue;

    private void Awake()
    {
        if (ghostHolder.isRecord) //Resets data in the lists, timeValue and timer
        {
            ghostHolder.ResetData();
            timeValue = 0;
            timer = 0;
        }
    }

    private void Update()
    {
        timer += Time.unscaledDeltaTime;
        timeValue += Time.unscaledDeltaTime;

        if(ghostHolder.isRecord & timer >= 1 / ghostHolder.recordFrequency) //Adds to the lists ghostHolder.recordFrequency/sec
        {
            ghostHolder.timeStamp.Add(timeValue);
            ghostHolder.position.Add(this.transform.position);
            //ghostHolder.rotation.Add(this.transform.eulerAngles);

            timer = 0;
        }

    }
}