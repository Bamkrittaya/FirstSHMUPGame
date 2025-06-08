using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // For handling UI elements
using UnityEngine.SceneManagement;  // For scene management (for reloading the scene)


public class MainMenu : MonoBehaviour
{
    // References to the UI elements
    public GameObject mainMenuUI;  // Main Menu UI (buttons like Play, Exit)
    public GameObject helpUI;      // Help UI (the screen explaining how to play)

    // Method to show the Help UI
    public void ShowHelp()
    {
        //mainMenuUI.SetActive(false);  // Hide the Main Menu UI
        helpUI.SetActive(true);       // Show the Help UI
    }

    // Method to go back to the Main Menu UI
    public void BackToMainMenu()
    {
        mainMenuUI.SetActive(true);   // Show the Main Menu UI
        helpUI.SetActive(false);      // Hide the Help UI
    }

    // Optional method to start the game (if needed)
    public void PlayGame()
    {
        // Replace "Game" with the actual name of your game scene
        SceneManager.LoadScene("Game");
        Debug.Log("Game Started!");
        
    }

    // Optional method to quit the game
    public void QuitGame()
    {
        Application.Quit();  // Quit the application in a built game
        Debug.Log("Game Quit");
    }

}
