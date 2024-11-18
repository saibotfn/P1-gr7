using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DrivePoints : MonoBehaviour
{
    public float pointsPerSecond = 10f;
    private float currentPoints = 0f;
    private bool isDriving = false;

    public TextMeshProUGUI pointsDisplay; // TextMeshProUGUI for modern Unity versions

    void Update()
    {
        if (isDriving)
        {
            currentPoints += pointsPerSecond * Time.deltaTime;

            if (pointsDisplay != null)
            {
                pointsDisplay.text = "Points: " + Mathf.FloorToInt(currentPoints);
            }
        }
    }

    public void StartDriving() => isDriving = true;

    public void StopDriving() => isDriving = false;

    public float GetPoints() => currentPoints;
}