using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GhostRecorder : MonoBehaviour
{
    public GhostHolder ghostHolder;
    //If working on implementing ghost play on 2 levels: Create ghostHolder for level 1 and 2

    private float timer;
    private float timeValue;
    ScenesManager scenesManager;

    private void Awake()
    {
        scenesManager = FindObjectOfType<ScenesManager>();
        ghostHolder.ResetData();
        timeValue = 0;
        timer = 0;
    }

    private void Update()
    {
            timer += Time.unscaledDeltaTime;
            timeValue += Time.unscaledDeltaTime;

            if (ghostHolder.isRecord & timer >= 1 / ghostHolder.recordFrequency) //Adds to the lists ghostHolder.recordFrequency/sec
            {
                ghostHolder.timeStamp.Add(timeValue);
                ghostHolder.position.Add(this.transform.position);
                //ghostHolder.rotation.Add(this.transform.eulerAngles);

                timer = 0;
            }
    }
}