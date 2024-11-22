using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed = 0f;        // Bilens aktuelle hastighed
    public float maxSpeed = 10f;   // Maksimal hastighed
    public float acceleration = 2f; // Hvor hurtigt bilen accelererer
    public float deceleration = 2f; // Hvor hurtigt bilen bremser
    public float sideSpeed = 5f;   // Sidel�ns hastighed

    private float horizontalInput; // Input til sidel�ns bev�gelse

    void Start()
    {
        // S�rg for at bilen starter med den rigtige rotation (peger opad)
        transform.rotation = Quaternion.Euler(0, 0, 0); // S�t rotationen til 0 p� Z-aksen (peger opad)
    }

    void Update()
    {
        // Input til sidel�ns bev�gelse (A/D eller piletasterne venstre/h�jre)
        horizontalInput = Input.GetAxis("Horizontal");

        // Input til hastighed (W/S eller op/ned)
        float verticalInput = Input.GetAxis("Vertical");

        // Juster hastigheden (W = acceleration, S = deceleration)
        if (verticalInput > 0) // W-tasten: Acceler�r
        {
            speed += acceleration * Time.deltaTime;
        }
        else if (verticalInput < 0) // S-tasten: S�nk hastigheden
        {
            speed -= deceleration * Time.deltaTime;
        }

        // Begr�ns hastigheden til at v�re mellem 0 og maxSpeed
        speed = Mathf.Clamp(speed, 0, maxSpeed);

        // Bev�g bilen opad langs y-aksen (fremad)
        // Bilen skal kun bev�ge sig opad langs y-aksen uden rotation
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        // Bev�g bilen sidel�ns langs x-aksen
        transform.Translate(Vector2.right * horizontalInput * sideSpeed * Time.deltaTime);
    }
    // Kollision med objekter
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Kollision med: " + collision.gameObject.name);
        Destroy(collision.gameObject); // Fjern objektet ved kollision
        speed = Mathf.Clamp(speed - 2f, 0, maxSpeed); // S�nk bilens hastighed
    }
}