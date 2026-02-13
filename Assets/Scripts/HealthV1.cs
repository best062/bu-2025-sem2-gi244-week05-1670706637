using UnityEngine;

public class HealthV1 : MonoBehaviour
{
    public int hp = 100;
    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
