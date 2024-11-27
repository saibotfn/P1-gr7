using UnityEngine;

public class FollowPlayerY : MonoBehaviour
{
    public Transform player; // Referencen til spillerens transform
    public float fixedXPosition = 0f; // Den faste x-position for kameraet
    public float offsetY = 2f; // En valgfri offset i y-retningen

    void LateUpdate()
    {
        if (player != null)
        {
            // Følg spillerens y-position og bevar x-positionen fast
            transform.position = new Vector3(
                fixedXPosition, 
                player.position.y + offsetY, 
                transform.position.z
            );
        }
    }
}
