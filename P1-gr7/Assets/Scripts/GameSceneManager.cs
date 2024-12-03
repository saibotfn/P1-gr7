using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameSceneManager : MonoBehaviour
{
    public GameObject[] characterCarPrefabs; // Prefabs for all character-car combinations
    public Transform playerTransform;        // Reference to the existing Player transform (from TrackSpawner)

    public float speed = 0f;
    public float maxSpeed = 10f;
    private Animator animator;
    SFXManager sFXManager;
    private GhostHolder ghostHolder;

    [SerializeField] CinemachineVirtualCamera camera;
    
    [SerializeField] TrackGeneration trackSpawner;

    private void Awake()//Henter SFX manager, så lyde kan tilgås
    {
        sFXManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<SFXManager>();
    }



    void Start()
    {
        

        // Retrieve selected character and car indices from PlayerPrefs
        //int selectedCharacter = PlayerPrefs.GetInt("SelectedCharacter", -1);
        //int selectedCar = PlayerPrefs.GetInt("SelectedCar", -1);

        int selectedCharacter = PlayerSelections.instance.character;
        int selectedCar = PlayerSelections.instance.car;

        Debug.Log("chcarfacter int from selection"+selectedCharacter);
        Debug.Log("car int from selection"+selectedCar);



        // Ensure both selections are valid
        if (selectedCharacter == -1 || selectedCar == -1)
        {
            Debug.LogError("Selection data is missing. Default player will be used.");
            return;
        }

        // Calculate prefab index (adjust this based on your prefab organization logic)
        int prefabIndex = -1;

        if(selectedCar == 0 && selectedCharacter == 0){
            prefabIndex = 0;
        }
        if(selectedCar == 0 && selectedCharacter == 1){
            prefabIndex = 1;}

        if(selectedCar == 1 && selectedCharacter == 0){
            prefabIndex = 2;}

        if(selectedCar == 1 && selectedCharacter == 1){
            prefabIndex = 3;}


        // Validate prefab index
        if (prefabIndex < 0 || prefabIndex >= characterCarPrefabs.Length)
        {
            Debug.LogError("Invalid prefab index. Default player will be used.");
            return;
        }

        Debug.Log("character index" + prefabIndex);

        // Spawn the selected prefab at the position of the existing player transform
        GameObject player = Instantiate(characterCarPrefabs[prefabIndex], playerTransform.position, playerTransform.rotation);

        ghostHolder = player.GetComponent<GhostRecorder>().ghostHolder;

        camera.Follow = player.transform;
        trackSpawner.player = player.transform;
        trackSpawner.drivePoints = player.GetComponent<DrivePoints>();
        trackSpawner.ghostHolder = ghostHolder;

        // Optionally, parent the new player object to the TrackSpawner, if needed
        player.transform.parent = playerTransform.parent;

        // Disable or remove the default Player object from the TrackSpawner, if necessary
        if (playerTransform.gameObject.activeSelf)
        {
            playerTransform.gameObject.SetActive(false);
        }

        Debug.Log($"Spawned prefab: {characterCarPrefabs[prefabIndex].name}");
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
        speed = Mathf.Clamp(speed - 7f, 0, maxSpeed);

        // Aktivér "Hit"-animation
        if (animator != null)
        {
            animator.SetTrigger("Hit");
        }

        sFXManager.PlaySFX(sFXManager.CollisionObstacle); //Spiller lyd til collision med sten/skrald/mm

        // Fjern objektet
        Destroy(collision.gameObject);
    }
    }
}