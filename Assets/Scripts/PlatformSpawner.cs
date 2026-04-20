using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject prefabToSpawn; // Drag your prefab her
    public float spawnInterval = 2.0f; // Seconds between spawns
    public Vector2 spawnRange1 = new Vector2(-8, -2); // Min and Max X
    public Vector2 spawnRange2 = new Vector2(2, 8); // Min and Max X
    public PlatformPooler platformPooler;

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
        float random1 = Random.Range(spawnRange1.x, spawnRange1.y);
        float random2 = Random.Range(spawnRange2.x, spawnRange2.y);
        Vector3 spawnPos1 = new Vector3(random1, 14, 0);
        Vector3 spawnPos2 = new Vector3(random2, 14, 0);


        GameObject platform1 = platformPooler.GetPooledObject();
        if (platform1 != null)
        {
            platform1.transform.position = spawnPos1;
            platform1.SetActive(true);
        }

        GameObject platform2 = platformPooler.GetPooledObject();
        
        
        if (platform2 != null)
        {
            platform2.transform.position = spawnPos2;
            platform2.SetActive(true);
        }
    }
}
