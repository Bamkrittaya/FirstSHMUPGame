using UnityEngine;
using UnityEngine.UI;  // For handling UI elements
using UnityEngine.SceneManagement;  // For scene management (for reloading the scene)
using System.Collections;  // For using coroutines
using System.Collections.Generic;  // For using lists and collections

public class GameOver : MonoBehaviour
{
    public GameObject gameOverUI;  // The UI elements to be shown on GameOver
    public Text gameOverText;      // The GameOver text
    public Text gameOverTextShadow;      // The GameOver text
    public Text scoreText;         // The score text
    public Text highestScoreText;  // Reference for the highest score text
    public Button restartButton;   // The restart button
    public Button mainMenuButton;  // The main menu button

    private int finalScore;  // The score to be displayed when the game ends

    public AudioManager audioManager;  // Reference to the AudioManager to change background music

    public void ShowGameOver(int score)
    {
        finalScore = score;
        // Start the coroutine to delay the GameOver screen
        StartCoroutine(ShowGameOverWithDelay());
    }

    // Coroutine to handle the delay of the GameOver UI
    private IEnumerator ShowGameOverWithDelay()
    {
        // Optionally, you can add a delay here to show the player death effect
        // For example, if you want to wait for 2 seconds to let the death animation play
        yield return new WaitForSeconds(1f);  // Wait for 2 seconds (adjust as necessary)

        scoreText.text = "Score: " + finalScore.ToString();  // Display the score
        // Get the highest score from PlayerPrefs and update the highest score text
        int highestScore = PlayerPrefs.GetInt("HighestScore", 0);  // Load highest score from PlayerPrefs
        highestScoreText.text = "Highest Score: " + highestScore.ToString();  // Display highest score
        
        Debug.Log("Final Score: " + finalScore);
        Debug.Log(highestScore);
        // Now update the UI text based on the score
        if (finalScore <= 0)
        {
            gameOverTextShadow.text = "No way!!";  // Set the text to "GAME OVER"
            gameOverText.text = "No way!!";  // Set the text to "GAME OVER"
        }
        else if (finalScore == highestScore)
        {
            gameOverTextShadow.text = "Amazing!!";  // Set the text to "GAME OVER"
            gameOverText.text = "Amazing!!";  // Set the text to "GAME OVER"
        }
        else
        {
            gameOverTextShadow.text = "You did Great";  // Set the text to "GAME OVER"
            gameOverText.text = "You did Great";  // Set the text to "GAME OVER"
        }

        
        // Show all necessary GameOver UI elements
        gameOverUI.SetActive(true);  // Activate the background
        gameOverText.gameObject.SetActive(true);  // Activate the "Game Over" text
        gameOverTextShadow.gameObject.SetActive(true);  // Activate the shadow text
        scoreText.gameObject.SetActive(true);  // Activate the score text
        highestScoreText.gameObject.SetActive(true);  // Activate the highest score text
        restartButton.gameObject.SetActive(true);  // Activate the restart button
        mainMenuButton.gameObject.SetActive(true);  // Activate the main menu button
        // Play the Game Over music
        audioManager.PlayGameOverMusic();  // Play the game over music
    }

    // Start the game again
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  // Reload the current scene
    }

    // Go back to the main menu
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");  // Replace "MainMenu" with the actual scene name for your main menu
    }

    // Start is called before the first frame update
    void Start()
    {
        // Hide the GameOver UI initially
        gameOverUI.SetActive(false);

        // Assign button functions
        restartButton.onClick.AddListener(RestartGame);
        mainMenuButton.onClick.AddListener(GoToMainMenu);
    }
}
