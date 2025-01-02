using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIController : MonoBehaviour
{
    public Transform playerCar;  // Reference to the player's car
    public float lateralOffset = 3.0f;  // Offset to the side of the player
    public float smoothTime = 0.3f;     // Time for the smooth damp movement

    private Vector3 velocity = Vector3.zero; // Internal velocity for SmoothDamp

    void Update()
    {
        if (playerCar != null)
        {
            // Calculate the target position
            Vector3 targetPosition = new Vector3(playerCar.position.x + lateralOffset, playerCar.position.y, transform.position.z);

            // Smoothly move the enemy car to the target position
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}