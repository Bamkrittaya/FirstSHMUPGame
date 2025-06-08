using UnityEngine;
using UnityEngine.SceneManagement;  // For scene management
using UnityEngine.UI;  // For button interaction

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;  // The Pause Menu UI panel
    public GameObject helpUI;       // The Help UI screen (if you want to show the Help UI from the Pause Menu)
    public string currentSceneName; // Store the name of the current scene to restart
    public AudioManager audioManager; // Reference to the AudioManager to change background music
    void Update()
    {
        // Check for the Escape key press
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Toggle the Pause Menu
            if (pauseMenuUI.activeSelf)
            {
                Resume();  // If the menu is already active, resume the game
            }
            else
            {
                Pause();  // If the menu is not active, show the pause menu
            }
        }
    }

    // Method to show the Pause Menu
    public void Pause()
    {
        pauseMenuUI.SetActive(true);   // Show the pause menu
        Time.timeScale = 0f;           // Pause the game (stop all time-based movement)
        helpUI.SetActive(false);
        audioManager.PlayPause();  // Play the help music
        audioManager.PauseBackgroundMusic();  // Pause the background music

    }

    // Method to resume the game
    public void Resume()
    {
        pauseMenuUI.SetActive(false);  // Hide the pause menu
        Time.timeScale = 1f;           // Resume the game (restore normal time flow)
        audioManager.ResumeBackgroundMusic();  // Pause the background music

    }

    // Method to restart the game (reload the current scene)

    // Method to show the Help UI (optional)
    public void ShowHelp()
    {
        helpUI.SetActive(true);    // Show the Help UI
        pauseMenuUI.SetActive(false);  // Hide the Pause Menu

    }

    // Method to exit the game (quit application)
    public void ExitGame()
    {
        Application.Quit();  // Quit the application
        Debug.Log("Game Quit");
    }
}
