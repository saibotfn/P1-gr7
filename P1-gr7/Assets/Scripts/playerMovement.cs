using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class playerMovement : MonoBehaviour
{
    public float speed = 0f;        // Bilens aktuelle hastighed
    public float maxSpeed = 10f;   // Maksimal hastighed
    public float acceleration = 4f; // Hvor hurtigt bilen accelererer
    public float deceleration = 7f; // Hvor hurtigt bilen bremser
    public float verticalSpeed = 13f;   // Sidelæns hastighed
    public float horizontalSpeed = 6f; // speed of swerving
    private Animator animator;      //sætter animatoren op så bilen kan dreje rundt
    private float currentSpeed;
    public float obstacleSlowdown = 10f;

    private float horizontalInput; // Input til sidelæns bevægelse
    SFXManager sFXManager;

    private bool canMove = false; // Flag to control movement

    private void Awake() 
    {
        sFXManager = FindObjectOfType<SFXManager>();// Initialize SFXManager
    }
    void Start()
    {
        // Sørg for at bilen starter med den rigtige rotation (peger opad)
        transform.rotation = Quaternion.Euler(0, 0, 0); // Sæt rotationen til 0 på Z-aksen (peger opad)
        animator = GetComponent<Animator>(); //Finder animator componenten frem
        currentSpeed = verticalSpeed;

        // Initialize SFXManager

        // Start the coroutine to enable movement after 4 seconds
        StartCoroutine(EnableMovementAfterDelay(4f));
    }

    IEnumerator EnableMovementAfterDelay(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);
        // Enable movement
        canMove = true;
    }

    private void Update()
    {
        Debug.Log("din far er: " + currentSpeed);
        if (!canMove) return; // Prevent movement if canMove is false

        // Adjust speed based on input
        if (Input.GetKey(KeyCode.Period))
        {
            currentSpeed += acceleration * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.Comma))
        {
            currentSpeed -= deceleration * Time.deltaTime;
        }
        else
        {
            // Gradually return to default speed (verticalSpeed variable)
            if (currentSpeed > verticalSpeed)
            {
                currentSpeed -= deceleration * Time.deltaTime;
                if (currentSpeed < verticalSpeed)
                {
                    currentSpeed = verticalSpeed;
                }
            }
            else if (currentSpeed < verticalSpeed)
            {
                currentSpeed += acceleration * Time.deltaTime;
                if (currentSpeed > verticalSpeed)
                {
                    currentSpeed = verticalSpeed;
                }
            }
        }
        transform.Translate(Vector3.up * currentSpeed * Time.deltaTime);

        // Horizontal movement based on player input
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * horizontalSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Hvis bilen rammer en barriere
        if (collision.gameObject.CompareTag("Barrier"))
        {
            Debug.Log("Bilen ramte en barriere. Ingen handling.");

            sFXManager.PlaySFX(sFXManager.BarrierCollision); //Spiller lyd, når man rammer barriere

            return; // Gør intet
        }
        // Hvis bilen rammer et objekt, der skal destrueres
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Bilen ramte et objekt: " + collision.gameObject.name);

            // Sænk bilens hastighed
            currentSpeed = Mathf.Clamp(currentSpeed - obstacleSlowdown, 0, maxSpeed);

            // Aktivér "Hit"-animation
            if (animator != null)
            {
                animator.SetTrigger("Hit");
            }

            // Fjern objektet
            Destroy(collision.gameObject);
            if (sFXManager != null)
            {
                sFXManager.PlaySFX(sFXManager.CollisionObstacle); //Spiller lyd til collision med sten/skrald/mm
            }
            else if (sFXManager == null)
            {
                Debug.Log("sFXManager is null");
            }
        }
    }
}