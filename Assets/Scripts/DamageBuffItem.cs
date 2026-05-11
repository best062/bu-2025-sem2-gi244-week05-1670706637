using UnityEngine;

public class DamageBuffItem : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 3f; 
    public float bottomBound = -10f; 

    void Update()
    {
        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        if (transform.position.z < bottomBound)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Food>() != null)
        {
            PlayerController.buffMultiplier = 2; 
            Debug.Log("ยิงโดนไอเทมบัฟแล้ว! ดาเมจกระสุน x2");
            
            Destroy(other.gameObject); 
            
            Destroy(gameObject); 
        }
    }
}