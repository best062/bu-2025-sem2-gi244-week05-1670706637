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
        bool isSpawnedAll = spwanedEnemies >= wave.enemiesCount;
        bool isAllDead = GameObject.FindGameObjectsWithTag("Enemy").Length == 0;
        return isSpawnedAll && isAllDead;
    }

    void Update()
    {
        float t = Time.time;
        
        if (spwanedEnemies < wave.enemiesCount && t >= nextSpawnTime)
        {
            Spawn();
            spwanedEnemies++;
            
            float randomInterval = Random.Range(1f, 3f);
            nextSpawnTime = t + randomInterval;
        }
        
        int enemiesAlive = GameObject.FindGameObjectsWithTag("Enemy").Length;
        UIManager.Instance.UpdateEnemyCount(enemiesAlive);
    }

    void Spawn()
    {
        float randomInterval = Random.Range(0f, 100f);
        int enemyIndex = 0;
        if (wave.enemiesPrefab.Length >= 3)
        {
            if (randomInterval < 60f)
            {
                enemyIndex = 0;
            }
            else if (randomInterval < 95f)
            {
                enemyIndex = 1;
            }
            else
            {
                enemyIndex = 2;
            }
        }
        else
        {
            enemyIndex = Random.Range(0, wave.enemiesPrefab.Length);
        }
        
        int pointIndex = Random.Range(0, spawnPoints.Length);
        
        var prefab = wave.enemiesPrefab[enemyIndex];
        var point = spawnPoints[pointIndex];
        
        Instantiate(prefab, point.position, Quaternion.Euler(0,180,0));
    }
}