using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject scorePrefab;

    public float delayToSpawn = 1f;
    private float timeToSpawn = 2f;

    void Update()
    {
        if (Time.time >= timeToSpawn)
        {
            SpawnScore();
            timeToSpawn = Time.time + delayToSpawn;
        }
    }

    void SpawnScore()
    {
        Instantiate(scorePrefab, spawnPoint.position, Quaternion.identity);
    }
}
