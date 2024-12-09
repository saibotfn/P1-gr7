using UnityEngine;

public class FollowPlayerY : MonoBehaviour
{
    public class CameraFollowY : MonoBehaviour
    {
        public Transform player; // Reference to the player's transform
        public float yOffset = 1f; // Offset to keep the player in the top lower third

        void Update()
        {
            if (player != null)
            {
                // Calculate the new camera position
                float newYPosition = player.position.y + yOffset;
                transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);
            }
        }
    }
}
