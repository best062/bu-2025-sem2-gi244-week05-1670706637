using UnityEngine;
using TMPro; 

public class UIManager : MonoBehaviour
{
    
    public static UIManager Instance;

    [Header("UI Text Components")]
    public TextMeshProUGUI ammoText;
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI enemyText;
    public TextMeshProUGUI baseHealthText;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }
    
    public void UpdateAmmo(int currentAmmo, int maxAmmo)
    {
        ammoText.text = "Ammo: " + currentAmmo + " / " + maxAmmo;
    }
    
    public void UpdateWave(int currentWave, int maxWave)
    {
        waveText.text = "Wave: " + currentWave + " / " + maxWave;
    }
    
    public void UpdateEnemyCount(int count)
    {
        enemyText.text = "Enemies Alive: " + count;
    }
    public void UpdateBaseHealth(int currentHealth, int maxHealth)
    {
        baseHealthText.text = "Base HP: " + currentHealth + " / " + maxHealth;
    }
}