using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    [Header("Health Settings")]
    public float maxHealth = 5000f; 
    private float currentHealth;
    private Slider healthSlider;

    [Header("Movement & Game Over")]
    public float bottomBound = -10f; 

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (transform.position.z < bottomBound)
        {
            BossReachedBase();
        }
    }

    public void SetHealthUI(Slider uiSlider)
    {
        healthSlider = uiSlider;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (healthSlider != null) healthSlider.value = currentHealth;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (healthSlider != null) healthSlider.gameObject.SetActive(false);
        FindObjectOfType<LevelEndManager>().WinLevel(); 
        Destroy(gameObject);
    }

    private void BossReachedBase()
    {
        Debug.Log("บอสบุกเข้าบ้านได้! บ้านแตก!");
        GameState gameState = FindObjectOfType<GameState>();
        if (gameState != null)
        {
            gameState.TriggerGameOver(); 
        }
        if (healthSlider != null) healthSlider.gameObject.SetActive(false);
        Destroy(gameObject);
    }
}