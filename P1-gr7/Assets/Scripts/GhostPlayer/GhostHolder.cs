using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GhostHolder : ScriptableObject
{
    public bool isRecord;
    public bool isReplay;
    public float recordFrequency;
    public float finishTime;

    public List<float> timeStamp = new List<float>();
    public List<Vector2> position = new List<Vector2>();
    public List<Vector2> rotation = new List<Vector2>();

    public void ResetData()
    {
        timeStamp.Clear();
        position.Clear();
        rotation.Clear();
    }
}
