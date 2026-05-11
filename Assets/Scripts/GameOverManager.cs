using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1f; 
    }

    public void RetryGame()
    {
        SceneManager.LoadScene("LevelSelection"); 
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Scenes/Start Game"); 
    }
}