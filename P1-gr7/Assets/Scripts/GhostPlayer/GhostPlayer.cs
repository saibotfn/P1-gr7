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

        if (ghostHolder.recordTimeStamp.Count == 0) //hides ghost if not replaying
        {
            GetComponent<Renderer>().enabled = false;
        }
    }

    
    private void Update() //Increments timeValue and calls methods GetIndex() and SetTransform() which moves the ghost car
    {
        if (!(ghostHolder.recordTimeStamp.Count == 0) && !(ghostHolder.recordPosition.Count == 0)) //Only runs if lists aren't empty
        {
            // Checks if the list are empty and only runs the for-loop if not
            timeValue += Time.unscaledDeltaTime;

            if (ghostHolder.isReplay)
            {
                GetIndex();
                SetTransform();
            }
        }
    }
    private void GetIndex() //For-loop increases the indices
    {
        for (int i = 0; i < ghostHolder.recordTimeStamp.Count - 2; i++)
        {
            if (ghostHolder.recordTimeStamp[i] == timeValue)
            {
                index1 = i;
                index2 = i;
                return;
            }
            else if (ghostHolder.recordTimeStamp[1] < timeValue & timeValue < ghostHolder.recordTimeStamp[i + 1])
            {
                index1 = i;
                index2 = i + 1;
                return;
            }
        }

        //Sets the indices to the last index 
        index1 = ghostHolder.recordTimeStamp.Count - 1;
        index2 = ghostHolder.recordTimeStamp.Count - 1;
        
               
    }
    private void SetTransform() //Moves the ghost car according to the position in the list. Uses linear interpolation to calculate the positions between indices ensuring smooth movement
    {
        if (index1 == index2)
        {
            this.transform.position = ghostHolder.recordPosition[index1];
          
            //this.transform.eulerAngles = ghostHolder.rotation[index1];
        }
        else
        {
            float interpolationFactor = (timeValue - ghostHolder.recordTimeStamp[index1]) / (ghostHolder.recordTimeStamp[index2] - ghostHolder.
                recordTimeStamp[index1]);

            this.transform.position = Vector2.Lerp(ghostHolder.recordPosition[index1], ghostHolder.recordPosition[index2], interpolationFactor);
            //this.transform.eulerAngles = Vector2.Lerp(ghostHolder.rotation[index1], ghostHolder.rotation[index2], interpolationFactor);
        }
    }
    
}
