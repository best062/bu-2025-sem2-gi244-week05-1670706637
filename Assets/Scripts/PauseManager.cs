using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PauseManager : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject pausePanel;
    public GameObject settingsPanel;

    [Header("Sound Settings (Optional)")]
    public Scrollbar volumeSlider;       
    public TextMeshProUGUI volumeText; 

    private bool isPaused = false;

    void Start()
    {
        // ซ่อนหน้าต่างตอนเริ่มเกม
        if (pausePanel != null) pausePanel.SetActive(false);
        if (settingsPanel != null) settingsPanel.SetActive(false);

        // โหลดค่าเสียงที่เคยตั้งไว้จากหน้า Main Menu
        float savedVolume = PlayerPrefs.GetFloat("GameVolume", 1f);
        if (volumeSlider != null) volumeSlider.value = savedVolume;
        SetVolume(savedVolume);
    }

    void Update()
    {
        // กดปุ่ม Esc (Escape) เพื่อเปิด/ปิดหน้า Pause
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                // ถ้าเปิด Settings อยู่ ให้ปิด Settings กลับมาหน้า Pause ก่อน
                if (settingsPanel != null && settingsPanel.activeSelf)
                {
                    CloseSettings();
                }
                else
                {
                    ResumeGame();
                }
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        if (pausePanel != null) pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        if (pausePanel != null) pausePanel.SetActive(false);
        if (settingsPanel != null) settingsPanel.SetActive(false);
    }

    public void OpenSettings()
    {
        if (pausePanel != null) pausePanel.SetActive(false);
        if (settingsPanel != null) settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        if (settingsPanel != null) settingsPanel.SetActive(false);
        if (pausePanel != null) pausePanel.SetActive(true);
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

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Scenes/Start Game"); 
    }
}