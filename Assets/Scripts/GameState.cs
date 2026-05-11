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
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(other.gameObject);
            TakeDamage(1); 
        }
    }
    
    public void TakeDamage(int damage)
    {
        hitCount += damage; 
        UpdateHealthUI();   
        
        if (hitCount >= maxHits)
        {
            TriggerGameOver();
        }
    }
    
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
        Debug.Log("บ้านแตก! โชว์หน้า Game Over");
        
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true); 
        }
        
        Time.timeScale = 0f; 
    }
}