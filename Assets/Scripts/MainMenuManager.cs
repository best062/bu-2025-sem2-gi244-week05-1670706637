using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 
using TMPro; 

public class MainMenuManager : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject mainMenuUI;
    public GameObject settingsPanel;

    [Header("Sound Settings")]
    public Scrollbar volumeSlider;       
    public TextMeshProUGUI volumeText; 

    private void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat("GameVolume", 1f);
        
        if (volumeSlider != null)
        {
            volumeSlider.value = savedVolume; 
        }
        SetVolume(savedVolume); 
    }
    
    public void OpenSettings()
    {
        if (settingsPanel != null && mainMenuUI != null)
        {
            mainMenuUI.SetActive(false);  
            settingsPanel.SetActive(true); 
        }
    }
    
    public void CloseSettings()
    {
        if (settingsPanel != null && mainMenuUI != null)
        {
            settingsPanel.SetActive(false); 
            mainMenuUI.SetActive(true);   
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("LevelSelection"); 
    }

    public void ExitGame()
    {
        Debug.Log("กดออกจากเกมแล้ว!");
        Application.Quit();
    }
    
    public void SetVolume(float value)
    {
        AudioListener.volume = value; 
        
        if (volumeText != null)
        {
            volumeText.text = Mathf.RoundToInt(value * 100) + "%";
        }
        
        PlayerPrefs.SetFloat("GameVolume", value);
    }
}