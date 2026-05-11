using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public float maxHealth = 5000f; // เลือดบอสมหาศาล
    private float currentHealth;
    private Slider healthSlider;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    // รับหลอดเลือดมาจาก BossManager
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
        // บอสตาย = จบเกมด่านบอสชนะ
        if (healthSlider != null) healthSlider.gameObject.SetActive(false);
        FindObjectOfType<LevelEndManager>().WinLevel(); // สั่งจบด่าน
        Destroy(gameObject);
    }
}