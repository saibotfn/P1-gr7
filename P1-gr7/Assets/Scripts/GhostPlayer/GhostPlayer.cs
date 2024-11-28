using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GhostPlayer : MonoBehaviour
{
    public GhostHolder ghostHolder;
    float timeValue;
    int index1;
    int index2;

    

    private void Awake()
    {
        timeValue = 0;
        if (ghostHolder.isRecord)
        {
            GetComponent<Renderer>().enabled = false;
        }
    }

    private void Update()
    {
        timeValue += Time.unscaledDeltaTime;

        if (ghostHolder.isReplay)
        {
            GetIndex();
            SetTransform();
        }
    }
    private void GetIndex()
    {
        for (int i = 0; 1 < ghostHolder.timeStamp.Count - 2; i++)
        {
            if (ghostHolder.timeStamp[i] == timeValue)
            {
                index1 = i;
                index2 = i;
                return;
            }
            else if (ghostHolder.timeStamp[1] < timeValue & timeValue < ghostHolder.timeStamp[i + 1])
            {
                index1 = i;
                index2 = i + 1;
                return;
            }
        }

        index1 = ghostHolder.timeStamp.Count - 1;
        index2 = ghostHolder.timeStamp.Count - 1;
        
               
    }
    private void SetTransform()
    {
        if (index1 == index2)
        {
            this.transform.position = ghostHolder.position[index1];
            this.transform.eulerAngles = ghostHolder.rotation[index1];
        }
        else
        {
            float interpolationFactor = (timeValue - ghostHolder.timeStamp[index1]) / (ghostHolder.timeStamp[index2] - ghostHolder.
                timeStamp[index1]);

            this.transform.position = Vector2.Lerp(ghostHolder.position[index1], ghostHolder.position[index2], interpolationFactor);
            this.transform.eulerAngles = Vector2.Lerp(ghostHolder.rotation[index1], ghostHolder.rotation[index2], interpolationFactor);
        }
    }
    
}
