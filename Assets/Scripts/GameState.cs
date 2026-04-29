using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Android;

public class GameState : MonoBehaviour
{
    public int hitCount = 0;
    public int maxHits = 5;
    public const string ENEMY_TAG = "Enemy";
    
    void Start()
    {
        if (UIManager.Instance != null)
        {
            UIManager.Instance.UpdateBaseHealth(maxHits - hitCount, maxHits);
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(ENEMY_TAG))
        {
            hitCount++;  
            Destroy(other.gameObject);
            
            if (UIManager.Instance != null)
            {
                int currentHealth = maxHits - hitCount;
                UIManager.Instance.UpdateBaseHealth(currentHealth, maxHits);
            }
        }
        
        if (hitCount >= maxHits)
        {
            Debug.Log("Game Over");
            Time.timeScale = 0f;
        }
    }
}
