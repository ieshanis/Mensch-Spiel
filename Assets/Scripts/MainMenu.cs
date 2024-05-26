using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // Load the game scene (ensure your game scene is added in the Build Settings)
        SceneManager.LoadScene("GameScene");
    }

    public void OpenCredits()
    {
        // Code to open the settings menu (could be another scene or a UI panel)
        Debug.Log("Credits button clicked!");
    }


    public void ExitGame()
    {
        // Quit the game
        Debug.Log("Exit button clicked!");
        Application.Quit();
    }

    
}
