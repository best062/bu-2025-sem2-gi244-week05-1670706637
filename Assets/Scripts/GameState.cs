using UnityEngine;

public class GameState : MonoBehaviour
{
    [Header("Base Settings")]
    public int hitCount = 0;
    public int maxHits = 5;
    public const string ENEMY_TAG = "Enemy";
    
    [Header("UI Panels")]
    public GameObject gameOverPanel; 
    
    void Start()
    {
        UpdateHealthUI();
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }
    
    /*public void TakeDamage(int damage)
    {
        hitCount += damage; 
        UpdateHealthUI();   
        
        if (hitCount >= maxHits)
        {
            TriggerGameOver();
        }
    }*/
    
    private void UpdateHealthUI()
    {
        if (UIManager.Instance != null)
        {
            int currentHealth = maxHits - hitCount;
            if (currentHealth < 0) currentHealth = 0; 
            
            UIManager.Instance.UpdateBaseHealth(currentHealth, maxHits);
        }
    }
    
    public void TriggerGameOver()
    {
        Debug.Log("Game Over Triggered!");
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true); 
        }
        Time.timeScale = 0f; 
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(ENEMY_TAG))
        {
            hitCount++;  
            Destroy(other.gameObject);
            
            if (UIManager.Instance != null)
            {
                UIManager.Instance.UpdateBaseHealth(maxHits - hitCount, maxHits);
            }

            if (hitCount >= maxHits)
            {
                TriggerGameOver(); 
            }
        }
    }
}