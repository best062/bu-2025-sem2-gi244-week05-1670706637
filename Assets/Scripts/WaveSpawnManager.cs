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
        UIManager.Instance.UpdateWave(currentWave + 1, waves.Length);
    }

    void Update()
    {
        if (waveController.IsCompleted())
        {
            currentWave++;
            if (currentWave < waves.Length)
            {
                waveController.ChangeWave(waves[currentWave]);
                UIManager.Instance.UpdateWave(currentWave + 1, waves.Length);
            }
            else 
            {
                if (levelEndManager != null)
                {
                    levelEndManager.WinLevel();
                    this.enabled = false; 
                }
            }
        }
    }
}