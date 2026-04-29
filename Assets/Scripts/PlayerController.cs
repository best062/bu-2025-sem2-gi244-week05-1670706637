using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed;

    public float xRange = 10;

    public GameObject projectilePrefab;

    private float horizontalInput;

    private InputAction moveAction;

    private InputAction shootAction;
    
    [Header("Charge System")]
    private float chargeTime = 0f; 
    public float chargeDuration = 1.5f;
    
    [Header("Ammo System")]
    public int maxAmmo = 30; 
    private int currentAmmo; 
    public int normalCost = 1; 
    public int chargeCost = 3; 

    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        shootAction = InputSystem.actions.FindAction("Shoot");
    }
    
    private void Start()
    {
        currentAmmo = maxAmmo;
        UIManager.Instance.UpdateAmmo(currentAmmo, maxAmmo);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = moveAction.ReadValue<Vector2>().x;
        transform.Translate(horizontalInput * speed * Time.deltaTime * Vector3.right);

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            Debug.Log("Reloading...");
            
            currentAmmo = maxAmmo;
            UIManager.Instance.UpdateAmmo(currentAmmo, maxAmmo);
        }
        
        if (shootAction.IsPressed())
        {
            chargeTime += Time.deltaTime;
        }

        if (shootAction.WasReleasedThisFrame())
        {
            bool isCharged = chargeTime >= chargeDuration;
            int cost = isCharged ? chargeCost : normalCost;
            
            if (currentAmmo >= cost)
            {
                currentAmmo -= cost;
                UIManager.Instance.UpdateAmmo(currentAmmo, maxAmmo);
                
                GameObject projectile = Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
                if (projectile.TryGetComponent<Food>(out Food foodScript))
                {
                    if (isCharged)
                    {
                        foodScript.isPiercing = true;
                        foodScript.attackPoint *= 3;
                        projectile.transform.localScale *= 1.5f;
                    }
                }
            }
            else
            {
                Debug.Log("กระสุนไม่พอ! กด R เพื่อรีโหลด");
            }
            
            chargeTime = 0f;
        }
    }
}
