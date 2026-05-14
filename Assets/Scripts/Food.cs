using UnityEngine;

public class Food : MonoBehaviour
{
    public int attackPoint = 5;
    public bool isPiercing = false;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit: " + other.gameObject.name);
        /*var health = other.gameObject.GetComponent<HealthV1>();
        if (health != null)
        {
            var luck = Random.Range(0, 100);
            if (luck <= 50)
            {
                health.TakeDamage(attackPoint);
            }
            else
            {
                health.TakeDamage(attackPoint * 2);
                Debug.Log("Critical hit");
            }
            Destroy(gameObject);
        }*/

        // สุ่มระบบคริติคอลคำนวณดาเมจ
        var luck = Random.Range(0, 100);
        int finalDamage = attackPoint; 

        if (luck < 60) 
        {
            finalDamage = attackPoint; 
        }
        else if (luck < 90) 
        {
            finalDamage = attackPoint * 2;
            Debug.Log("Double Damage!");
        }
        else 
        {
            finalDamage = attackPoint * 3;
            Debug.Log("TRIPLE DAMAGE!!!");
        }
        
        if (other.gameObject.TryGetComponent<HealthV1>(out HealthV1 normalHealth))
        {
            normalHealth.TakeDamage(finalDamage);
            
            if (!isPiercing) Destroy(gameObject); 
        }
        
        else if (other.gameObject.TryGetComponent<BossHealth>(out BossHealth bossHealth))
        {
            bossHealth.TakeDamage(finalDamage);
            
            if (!isPiercing) Destroy(gameObject); 
        }
    }
}
