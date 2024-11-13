using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackGeneration : MonoBehaviour
{
    public GameObject trackPiecePrefab; //The track piece prefab
    public GameObject[] obstaclePrefabs; //Array of obstacle prefabs
    public Transform player; //References the player transform
    public float spawnDistance = 25.64f; //How far infront of the player the track start spawning
    public float pieceLenght = 12.82f; //Lenght of the track pieces
    private List<GameObject> activePieces = new List<GameObject>(); //Tracking the active pieces
    private float spawnPosTrack = 0.0f; //The spawn position of the track

    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            SpawnTrackPiece();
        }
        
    }

    void Update()
    {
        if (player.position.y > spawnPosTrack - 2 * spawnDistance)
        {
            SpawnTrackPiece();
            RemoveOldTrackPieces();
        }
    }
    void SpawnTrackPiece()
    {
        GameObject trackPiece = Instantiate(trackPiecePrefab, new Vector3(0, spawnPosTrack, 0), Quaternion.identity);
        activePieces.Add(trackPiece);
        SpawnObstacles(trackPiece.transform);
        Debug.Log("Track spawn position: " + spawnPosTrack);
        spawnPosTrack += pieceLenght;
    }
    void SpawnObstacles(Transform trackPiece)
    {
        int obstacleCount = Random.Range(1, 5);
        
        for (int i = 0; i < obstacleCount; i++)
        {
            GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
            Vector3 spawnPosObstacle = new Vector3(Random.Range(-9, 9), Random.Range(-pieceLenght / 2, pieceLenght / 2), 0);
            GameObject obstacleInstance = Instantiate(obstaclePrefab, trackPiece.position + spawnPosObstacle, Quaternion.identity, trackPiece);

        }
    }
    void RemoveOldTrackPieces()
    {
        if (activePieces.Count > 7)
        {
            Destroy(activePieces[0]);
            activePieces.RemoveAt(0);
        }

    }
}
