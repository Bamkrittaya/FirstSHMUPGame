using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;  // Singleton to easily access the ScoreManager
    public Text scoreText;  // Reference to the Text component (Text Legacy)
    public Text highestScoreText;  // Reference to display the highest score
    private int score = 0; // Starting score
    private int highestScore = 0; // Starting highest score

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Load the highest score from PlayerPrefs if it exists
        highestScore = PlayerPrefs.GetInt("HighestScore", 0);
        UpdateScore();
        UpdateHighestScore();
    }

    // Method to add points to the score
    public void AddPoint(int points)
    {
        score += points;
        // Check if the new score is the highest score
        if (score > highestScore)
        {
            PlayerPrefs.SetInt("HighestScore", score); // Save the new highest score
        }
        UpdateScore();
        UpdateHighestScore();
    }

    public int GetScore()
    {
        return score;  // Assuming 'score' is a private field in the ScoreManager
    }

    // Update the score text
    void UpdateScore()
    {
        scoreText.text =  score.ToString();
    }

    // Update the highest score text
    void UpdateHighestScore()
    {
        highestScoreText.text = highestScore.ToString();
    }
}
