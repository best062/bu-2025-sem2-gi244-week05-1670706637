using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndManager : MonoBehaviour
{
    [Header("Level Settings")]
    public int currentLevelIndex; 
    
    [Header("UI Settings")]
    public GameObject winPanel;
    
    private bool bossStarted = false; 

    private void Start()
    {
        if (winPanel != null) winPanel.SetActive(false);
    }

    public void WinLevel()
    {
        BossManager bossManager = FindObjectOfType<BossManager>();
        
        if (bossManager != null && !bossStarted)
        {
            bossStarted = true; 
            bossManager.StartBossSequence();
            return; 
        }
        TriggerWinUI();
    }

    private void TriggerWinUI()
    {
        PlayerPrefs.SetInt("Level" + currentLevelIndex + "_Cleared", 1);
        PlayerPrefs.Save();
        Debug.Log("บันทึกข้อมูลสำเร็จ! เคลียร์ด่าน: " + currentLevelIndex);
        
        Time.timeScale = 0f; 
        if (winPanel != null) winPanel.SetActive(true);
    }
    

    public void GoToLevelSelection()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("LevelSelection"); 
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("Scenes/Start Game"); 
    }
}