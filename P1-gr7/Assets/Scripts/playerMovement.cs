using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed = 0f;        // Bilens aktuelle hastighed
    public float maxSpeed = 10f;   // Maksimal hastighed
    public float acceleration = 2f; // Hvor hurtigt bilen accelererer
    public float deceleration = 2f; // Hvor hurtigt bilen bremser
    public float sideSpeed = 5f;   // Sidelæns hastighed

    private float horizontalInput; // Input til sidelæns bevægelse

    void Start()
    {
        // Sørg for at bilen starter med den rigtige rotation (peger opad)
        transform.rotation = Quaternion.Euler(0, 0, 0); // Sæt rotationen til 0 på Z-aksen (peger opad)
    }

    void Update()
    {
        // Input til sidelæns bevægelse (A/D eller piletasterne venstre/højre)
        horizontalInput = Input.GetAxis("Horizontal");

        // Input til hastighed (W/S eller op/ned)
        float verticalInput = Input.GetAxis("Vertical");

        // Juster hastigheden (W = acceleration, S = deceleration)
        if (verticalInput > 0) // W-tasten: Accelerér
        {
            speed += acceleration * Time.deltaTime;
        }
        else if (verticalInput < 0) // S-tasten: Sænk hastigheden
        {
            speed -= deceleration * Time.deltaTime;
        }

        // Begræns hastigheden til at være mellem 0 og maxSpeed
        speed = Mathf.Clamp(speed, 0, maxSpeed);

        // Bevæg bilen opad langs y-aksen (fremad)
        // Bilen skal kun bevæge sig opad langs y-aksen uden rotation
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        // Bevæg bilen sidelæns langs x-aksen
        transform.Translate(Vector2.right * horizontalInput * sideSpeed * Time.deltaTime);
    }
    // Kollision med objekter
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Kollision med: " + collision.gameObject.name);
        Destroy(collision.gameObject); // Fjern objektet ved kollision
        speed = Mathf.Clamp(speed - 2f, 0, maxSpeed); // Sænk bilens hastighed
    }
}