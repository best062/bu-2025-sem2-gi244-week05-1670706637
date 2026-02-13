using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    // [1] declare a public GameObject array for animal prefabs
    public GameObject[] animalPrefabs;
    // [2] declare a public int variable for animal index for testing instantiation
    private int animalIndex;
    public float spawnRangeX = 15;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnAnimal ), 2f, 4f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SpawnAnimal();
        }
    }

    void SpawnAnimal()
    {
            animalIndex = Random.Range(0, animalPrefabs.Length);
            Vector3 spawnPos = new(
                Random.Range(-spawnRangeX, spawnRangeX),
                transform.position.y,
                transform.position.z
            );
            Instantiate(
                animalPrefabs[animalIndex],
                spawnPos,
                animalPrefabs[animalIndex].transform.rotation
            );
    }
}
