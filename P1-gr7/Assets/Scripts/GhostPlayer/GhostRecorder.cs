using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostRecorder : MonoBehaviour
{
    public GhostHolder ghostHolder;
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

            ghostHolder.timeStamp.Add(timeValue);
            ghostHolder.position.Add(this.transform.position);
            ghostHolder.rotation.Add(this.transform.eulerAngles);

            timer = 0;
        }

    }
}
