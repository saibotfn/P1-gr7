using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostRecorder : MonoBehaviour
{
    public GhostHolder ghostHolder;
    //Create another GhostHolder to hold temporary values
    private float timer;
    private float timeValue;

    private void Awake()
    {
        if (ghostHolder.isRecord)
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

        if(ghostHolder.isRecord & timer >= 1 / ghostHolder.recordFrequency)
        {
            //Update the temporary values instead
            ghostHolder.timeStamp.Add(timeValue);
            ghostHolder.position.Add(this.transform.position);
            ghostHolder.rotation.Add(this.transform.eulerAngles);

            timer = 0;
        }

    }
}
// When ending game compare the ghostHolder temp to the ghostHolder.finishTime
// If it is less the set the ghostHolder variables to the temp ones