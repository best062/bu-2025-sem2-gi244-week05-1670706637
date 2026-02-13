using UnityEngine;

public class WaveController : MonoBehaviour
{
    public Transform[] spawnPoints;
    
    public Wave wave;
    private int spwanedEnemies = 0;
    private float nextSpawnTime = 0;

    public void ChangeWave(Wave wave)
    {
        this.wave = wave;
        spwanedEnemies = 0;
        nextSpawnTime = Time.time;
    }

    public bool IsCompleted()
    {
        return spwanedEnemies >= wave.enemiesCount;
    }
    void Update()
    {
        float t = Time.time;
        if (spwanedEnemies < wave.enemiesCount)
        {
            Spawn();
            spwanedEnemies++;
            nextSpawnTime = t + wave.spawnInterval;
        }
    }

    void Spawn()
    {
        int enemyIndex = Random.Range(0, wave.enemiesPrefab.Length);
        int pointIndex = Random.Range(0, spawnPoints.Length);
        
        var prefab = wave.enemiesPrefab[enemyIndex];
        var point = spawnPoints[pointIndex];
        
        Instantiate(prefab, point.position, Quaternion.Euler(0,180,0));
    }
}
