using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndManager : MonoBehaviour
{
    [Header("Level Settings")]
    public int currentLevelIndex; 
    
    public void WinLevel()
    {
        BossManager bossManager = FindObjectOfType<BossManager>();
            
        if (bossManager != null)
        {
            // ถ้าเป็นด่านบอส ให้เริ่มระบบบอสแทนการจบเกม
            bossManager.StartBossSequence();
        }
        else
        {
            // ถ้าไม่มีบอส ก็จบด่านปกติ
            FindObjectOfType<LevelEndManager>().WinLevel();
        }
        
        PlayerPrefs.SetInt("Level" + currentLevelIndex + "_Cleared", 1);
        PlayerPrefs.Save();
        Debug.Log("บันทึกข้อมูลสำเร็จ! เคลียร์ด่าน: " + currentLevelIndex);
        SceneManager.LoadScene("LevelSelection"); 
        
    }
}