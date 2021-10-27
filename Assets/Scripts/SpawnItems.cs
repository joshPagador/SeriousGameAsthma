using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{

    public GameObject[] itemsToSpawn;
    private GameObject tempObject;

    public Transform[] spawnPoints;

    void Start()
    {

        ShuffleItemsArray();
        ItemSpawn();
    
    }


    //shuffles the array
    void ShuffleItemsArray()
    {
        for (int i = 0; i < itemsToSpawn.Length; i++)
        {
            int rnd = Random.Range(0, itemsToSpawn.Length);
            tempObject = itemsToSpawn[rnd];
            itemsToSpawn[rnd] = itemsToSpawn[i];
            itemsToSpawn[i] = tempObject;
        }
    }

    void ItemSpawn()
    {

        for(int j = 0; j < spawnPoints.Length; j++)
        {
            Instantiate(itemsToSpawn[j], spawnPoints[j].position, transform.rotation);
        }

    }
}
