using UnityEngine;

public class WaveSpawnManager : MonoBehaviour
{
    public Wave[] waves;
    public WaveController waveController;
    private int currentWave = 0;
    
    [Header("LevelEndManager")]
    public LevelEndManager levelEndManager;
    
    void Start()
    {
        waveController.ChangeWave(waves[0]);
    }

    void Update()
    {
        if (waveController.IsCompleted())
        {
            currentWave++;
            
            // เช็คว่ายังมีเวฟเหลือไหม
            if (currentWave < waves.Length)
            {
                // ถ้ามีเวฟเหลือ ให้เล่นเวฟถัดไป
                waveController.ChangeWave(waves[currentWave]);
            }
            else // <--- ย้าย else เข้ามาอยู่ตรงนี้ครับ!
            {
                // เข้าเงื่อนไขนี้แปลว่าศัตรูตายหมดทุกเวฟแล้ว!
                if (levelEndManager != null)
                {
                    levelEndManager.WinLevel();
                    
                    // ปิดการทำงานของสคริปต์นี้เพื่อไม่ให้มันเรียกซ้ำรัวๆ
                    this.enabled = false; 
                }
            }
        }
    }
}