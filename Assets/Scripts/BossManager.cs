using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BossManager : MonoBehaviour
{
    [Header("Boss Settings")]
    public GameObject bossPrefab;
    public Transform middleSpawnPoint;
    public Slider bossHealthUI; 
    
    [Header("UI Countdown")]
    public TextMeshProUGUI countdownText; 

    [Header("Buff Item Settings")]
    public GameObject damageBuffPrefab;
    public Transform buffSpawnPoint;
    
    public void StartBossSequence()
    {
        Debug.Log("เริ่มระบบ Boss Sequence แล้ว!");
        StartCoroutine(BossRoutine());
    }

    private IEnumerator BossRoutine()
    {
        if (countdownText != null)
        {
            countdownText.gameObject.SetActive(true); 
            countdownText.text = "READY?";
            yield return new WaitForSeconds(1f);
            
            for (int i = 3; i > 0; i--)
            {
                countdownText.text = i.ToString();
                Debug.Log("Countdown: " + i);
                yield return new WaitForSeconds(1f);
            }
            
            countdownText.text = "WARNING: BOSS APPEARED!";
            yield return new WaitForSeconds(1.5f);
            countdownText.gameObject.SetActive(false); 
        }
        else
        {
            Debug.LogWarning("ไม่ได้ใส่ UI Countdown Text ในสคริปต์ BossManager!");
        }
        
        if (bossHealthUI != null) 
        {
            bossHealthUI.gameObject.SetActive(true);
        }
        
        GameObject bossInstance = Instantiate(bossPrefab, middleSpawnPoint.position, Quaternion.Euler(0, 180, 0));
        
        if (bossInstance.TryGetComponent<BossHealth>(out BossHealth bossHp))
        {
            bossHp.SetHealthUI(bossHealthUI);
            Debug.Log("ส่งมอบหลอดเลือด UI ให้บอสจัดการเรียบร้อย");
        }
        
        yield return new WaitForSeconds(5f); 
        
        if (damageBuffPrefab != null && buffSpawnPoint != null)
        {
            float randomX = Random.Range(-10f, 10f); 
            Vector3 randomSpawnPos = new Vector3(randomX, buffSpawnPoint.position.y, buffSpawnPoint.position.z);
            Instantiate(damageBuffPrefab, randomSpawnPos, Quaternion.identity);
            Debug.Log("เสกไอเทมบัฟคูณดาเมจแบบสุ่มตำแหน่งแล้ว!");
        }
    }
}