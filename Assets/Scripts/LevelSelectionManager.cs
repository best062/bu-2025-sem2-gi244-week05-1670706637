using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectionManager : MonoBehaviour
{
    [Header("Level Buttons")]
    public Button btnLevel1;
    public Button btnLevel2;
    public Button btnLevel3;
    public Button btnLevel4;
    public Button btnBossLevel; 

    private void Start()
    {
        int lvl1Cleared = PlayerPrefs.GetInt("Level1_Cleared", 0);
        int lvl2Cleared = PlayerPrefs.GetInt("Level2_Cleared", 0);
        int lvl3Cleared = PlayerPrefs.GetInt("Level3_Cleared", 0);
        int lvl4Cleared = PlayerPrefs.GetInt("Level4_Cleared", 0);
        
        if(btnLevel1 != null) btnLevel1.interactable = true;
        if(btnLevel2 != null) btnLevel2.interactable = (lvl1Cleared == 1);
        if(btnLevel3 != null) btnLevel3.interactable = (lvl2Cleared == 1);
        if(btnLevel4 != null) btnLevel4.interactable = (lvl2Cleared == 1);
        if(btnBossLevel != null) btnBossLevel.interactable = (lvl3Cleared == 1 && lvl4Cleared == 1);
    }
    
    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene("Level" + levelIndex); 
    }
    
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Scenes/Start Game"); 
    }
}