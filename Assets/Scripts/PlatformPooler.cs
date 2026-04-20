using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PlatformPooler : MonoBehaviour
{
    public static ObjectPool<GameObject> instance;
    private List<GameObject> pooledObjects = new List<GameObject>(); // list to hold the pooled objects
    private int amountToPool = 20;

    [SerializeField] private GameObject platformPrefab; // assign your prefab in the inspector


    void Start()
    {
        for (int i = 0; i < amountToPool; i++) // loop to create the specified number of objects
        {
            GameObject obj = Instantiate(platformPrefab);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++) // loop through the list to find an inactive object
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null; // return null if no inactive object is found
    }
}
