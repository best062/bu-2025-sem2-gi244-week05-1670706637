using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BossManager : MonoBehaviour
{
    [Header("Boss Settings")]
    public GameObject bossPrefab;
    public Transform middleSpawnPoint; // จุดเกิดบอส (จุดตรงกลาง)
    public Slider bossHealthUI; // หลอดเลือดบอส
    
    [Header("UI Countdown")]
    public TextMeshProUGUI countdownText;

    [Header("Buff Item Settings")]
    public GameObject damageBuffPrefab;
    public Transform buffSpawnPoint; // จุดเสกกล่องบัฟ

    // ฟังก์ชันนี้จะถูกเรียกเมื่อศัตรูเวฟปกติหมดแล้ว
    public void StartBossSequence()
    {
        StartCoroutine(BossRoutine());
    }

    private IEnumerator BossRoutine()
    {
        // 1. เริ่มนับถอยหลัง 3 วินาที
        countdownText.gameObject.SetActive(true);
        for (int i = 3; i > 0; i--)
        {
            countdownText.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }
        
        countdownText.text = "WARNING: BOSS APPEARED!";
        yield return new WaitForSeconds(1.5f);
        countdownText.gameObject.SetActive(false);
        
        bossHealthUI.gameObject.SetActive(true); 
        GameObject bossInstance = Instantiate(bossPrefab, middleSpawnPoint.position, Quaternion.identity);
        
        if (bossInstance.TryGetComponent<BossHealth>(out BossHealth bossHp))
        {
            bossHp.SetHealthUI(bossHealthUI);
        }
        
        yield return new WaitForSeconds(5f);
        if (damageBuffPrefab != null && buffSpawnPoint != null)
        {
            float randomX = Random.Range(-10f, 10f); 
            Vector3 randomSpawnPos = new Vector3(randomX, buffSpawnPoint.position.y, buffSpawnPoint.position.z);
            Instantiate(damageBuffPrefab, randomSpawnPos, Quaternion.identity);
            Debug.Log("เสกไอเทมบัฟแบบสุ่มตำแหน่งแล้ว!");
            Debug.Log("เสกบัฟคูณดาเมจแล้ว!");
        }
    }
}