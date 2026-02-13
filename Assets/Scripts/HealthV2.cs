using UnityEngine;

public class HealthV2 : MonoBehaviour
{
    public int maxHp = 100;
    private int accumDamage;
    public void TakeDamage(int damage)
    {
        accumDamage += damage;
        if (accumDamage >= maxHp)
        {
            Destroy(gameObject);
        }
    }
}
