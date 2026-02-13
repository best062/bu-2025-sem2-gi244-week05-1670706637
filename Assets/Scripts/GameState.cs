using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Android;

public class GameState : MonoBehaviour
{
    public int hitCount = 0;
    public const string ENEMY_TAG = "Enemy";
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(ENEMY_TAG))
        {
            hitCount++;    
        }
        
        if (hitCount >= 5)
        {
            Debug.Log("Game Over");
            Time.timeScale = 0f;
        }
    }
}
