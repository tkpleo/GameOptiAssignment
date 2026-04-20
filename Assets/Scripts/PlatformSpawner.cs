using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject prefabToSpawn; // Drag your prefab here
    public float spawnInterval = 2.0f; // Seconds between spawns
    public Vector2 spawnRangeX = new Vector2(-5, 5); // Min and Max X

    void Start()
    {
        // Start the repeated spawning process
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            SpawnObject();
            // Wait for the specified interval before the next spawn
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnObject()
    {
        // Generate a random position within your defined range
        float randomX = Random.Range(spawnRangeX.x, spawnRangeX.y);
        Vector3 spawnPos = new Vector3(randomX, 14, 0);

        // Create the object
        Instantiate(prefabToSpawn, spawnPos, Quaternion.identity);
    }
}
