using System;
using UnityEngine;

[Serializable]
public class Wave
{
    public GameObject[] enemiesPrefab;
    public int enemiesCount;
    public float spawnInterval = 1f;
    public float waveInterval = 5f;
}