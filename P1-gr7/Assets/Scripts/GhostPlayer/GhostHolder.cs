using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GhostHolder : ScriptableObject
{
    //Determines if recording or playing
    public bool isRecord;
    public bool isReplay;

    public float recordFrequency = 2; //Determines how often data is saved to the lists

    // Lists used to store time and positions
    public List<float> timeStamp = new List<float>();
    public List<Vector2> position = new List<Vector2>();
    // public List<Vector2> rotation = new List<Vector2>();

    // Lists used to store the record run
    public List<float> recordTimeStamp = new List<float>();
    public List<Vector2> recordPosition = new List<Vector2>();
    // public List<Vector2> recordRotation = new List<Vector2>();

    public void ResetData() // Resets the data in the temporary lists
    {
        timeStamp.Clear();
        position.Clear();
        //rotation.Clear();
    }

   public void UpdateRecord()
    {
        recordTimeStamp.Clear();
        recordPosition.Clear();
        recordTimeStamp.AddRange(timeStamp);
        recordPosition.AddRange(position);

    }
}
