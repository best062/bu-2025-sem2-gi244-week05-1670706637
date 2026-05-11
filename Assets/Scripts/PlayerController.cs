using UnityEngine;
using UnityEngine.InputSystem; 

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 10f;
    public float sprintSpeed = 20f; 
    public float xRange = 10f;

    public GameObject projectilePrefab;

    private float horizontalInput;
    private InputAction moveAction;
    private InputAction shootAction;
    
    [Header("Charge System")]
    private float chargeTime = 0f; 
    public float chargeDuration = 1f;
    
    [Header("Ammo System")]
    public int maxAmmo = 30; 
    private int currentAmmo; 
    public int normalCost = 1; 
    public int chargeCost = 3; 

    public static int buffMultiplier = 1;

    private void Awake()
    {
        if (InputSystem.actions != null)
        {
            moveAction = InputSystem.actions.FindAction("Move");
            shootAction = InputSystem.actions.FindAction("Shoot");
        }
    }
    
    private void Start()
    {
        currentAmmo = maxAmmo;
        if (UIManager.Instance != null)
        {
            UIManager.Instance.UpdateAmmo(currentAmmo, maxAmmo);
        }
    }

    void Update()
    {
        
        if (Time.timeScale == 0f) return;
        
        float currentSpeed = speed;
        if (Keyboard.current.leftShiftKey.isPressed || Keyboard.current.rightShiftKey.isPressed)
        {
            currentSpeed = sprintSpeed;
        }

        // ระบบเดิน (ซ้าย-ขวา)
        if (moveAction != null)
        {
            horizontalInput = moveAction.ReadValue<Vector2>().x;
            transform.Translate(horizontalInput * currentSpeed * Time.deltaTime * Vector3.right); 
        }
        
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
            currentAmmo = maxAmmo;
            if (UIManager.Instance != null)
            {
                UIManager.Instance.UpdateAmmo(currentAmmo, maxAmmo);
            }
        }
        
        if (Input.GetMouseButton(0) || (shootAction != null && shootAction.IsPressed()))
        {
            chargeTime += Time.deltaTime;
        }

        if (Input.GetMouseButtonUp(0) || (shootAction != null && shootAction.WasReleasedThisFrame()))
        {
            bool isCharged = chargeTime >= chargeDuration;
            int cost = isCharged ? chargeCost : normalCost; 
            
            if (currentAmmo >= cost)
            {
                currentAmmo -= cost; 
                if (UIManager.Instance != null)
                {
                    UIManager.Instance.UpdateAmmo(currentAmmo, maxAmmo); 
                }
                
                GameObject projectile = Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
                
                if (projectile.TryGetComponent<Food>(out Food foodScript))
                {
                    foodScript.attackPoint *= buffMultiplier;

                    if (isCharged)
                    {
                        foodScript.isPiercing = true; 
                        foodScript.attackPoint *= 5;
                        projectile.transform.localScale *= 2f; 
                        Debug.Log("ยิงชาร์จ! (กระสุนทะลุทะลวง)");
                    }
                    else
                    {
                        Debug.Log("ยิงธรรมดา");
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