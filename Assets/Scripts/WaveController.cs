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
        // 1. เช็คว่าเสกศัตรูออกมาครบตามจำนวนของเวฟนั้นแล้ว
        bool isSpawnedAll = spwanedEnemies >= wave.enemiesCount;
        
        // 2. เช็คว่าไม่มีศัตรูหลงเหลืออยู่ในฉากแล้ว (ใช้การค้นหา Tag ชื่อ Enemy)
        bool isAllDead = GameObject.FindGameObjectsWithTag("Enemy").Length == 0;

        // เวฟจะสมบูรณ์ก็ต่อเมื่อ เสกครบแล้ว "และ" ตายหมดแล้ว (ต้องใช้ &&)
        return isSpawnedAll && isAllDead;
    }

    void Update()
    {
        float t = Time.time;
        
        // เพิ่ม && t >= nextSpawnTime เพื่อให้มันรอเวลาตามที่กำหนดก่อนเสกตัวถัดไป
        if (spwanedEnemies < wave.enemiesCount && t >= nextSpawnTime)
        {
            Spawn();
            spwanedEnemies++;
            
            // สุ่มเวลาเกิดระหว่าง 1 ถึง 3 วินาที (ไม่ให้เกิดพร้อมกันรวดเดียว)
            float randomInterval = Random.Range(1f, 3f);
            nextSpawnTime = t + randomInterval;
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