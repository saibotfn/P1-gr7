using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DrivePoints : MonoBehaviour
{
  public float pointsPerUnit = 10f;  // Points earned per unit change in the Y-axis
    private float currentPoints = 0f; // Current score
    private float lastYPosition;      // Stores the previous Y position of the object


    public TextMeshProUGUI pointsDisplay; // TextMeshProUGUI for modern Unity versions

    void Start()
    {
        // Initialize the last Y position
        lastYPosition = transform.position.y;
    }

    void Update()
    {
        // Get the current Y position
        float currentYPosition = transform.position.y;

        // Calculate the difference in Y position
        float yDifference = Mathf.Abs(currentYPosition - lastYPosition);

        // If there's a change in Y position, increase points
        if (yDifference > 0)
        {
            currentPoints += yDifference * pointsPerUnit;

            // Update the points display if it exists
            if (pointsDisplay != null)
            {
                pointsDisplay.text = "Points: " + Mathf.FloorToInt(currentPoints);
            }
        }

        // Update the last Y position
        lastYPosition = currentYPosition;
    }

    // Get the current points (useful for other game logic)
    public float GetPoints()
    {
        return currentPoints;
    }
}