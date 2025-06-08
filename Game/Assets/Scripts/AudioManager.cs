using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // For scene management


public class AudioManager : MonoBehaviour
{
    [Header("-----Audio Sources-----")]
    [SerializeField] AudioSource backgroundMusic;  // Reference to the background music AudioSource
    [SerializeField] AudioSource SFXSource;  // Reference to the SFX AudioSource

    [Header("-----Audio Clips-----")]
    public AudioClip background;  // Background music clip
    public AudioClip gameOver;  // Game over music clip
    public AudioClip witchGood;  // Witch hit sound effect
    public AudioClip batDie;  // Bat hit sound effect
    public AudioClip playerHit;  // Player hit sound effect
    public AudioClip playerDie;  // Player die sound effect
    public AudioClip playerShoot;  // Player shoot sound effect
    public AudioClip Pause;  // Pause sound effect
    
    public AudioClip mainMenuBackground;  // Background music for the main menu
    public AudioClip buttonClick;  // Button click sound effect



    private float backgroundMusicTime;  // To store the current time of the background music

    private bool isBackgroundMusicPlaying = false;  // To check if the background music is playing

    public static AudioManager instance; // Static instance of AudioManager to access it globally

       /*private void Awake()
    {
        // Singleton pattern: If an instance of AudioManager already exists, destroy the duplicate
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // Keep the AudioManager across scenes
        }
        else
        {
            Destroy(gameObject);  // Destroy duplicate AudioManager instances
        }
    }*/


  private void Start()
    {
        // Check if we're in the main menu or game scene and set background music accordingly
        if (SceneManager.GetActiveScene().name == "MainMenu") // Replace "MainMenu" with your actual menu scene name
        {
            backgroundMusic.clip = mainMenuBackground;  // Set background music for main menu
        }
        else
        {
            backgroundMusic.clip = background;  // Set background music for game
        }

        backgroundMusic.loop = true;  // Loop the background music

        if (!isBackgroundMusicPlaying)  // Check if background music is already playing
        {
            backgroundMusic.Play();  // Play the background music
            isBackgroundMusicPlaying = true;  // Mark it as playing
        }

        backgroundMusicTime = backgroundMusic.time;  // Store the current position of the music
    }

    // Function to play game over music
    public void PlayGameOverMusic()
    {
        SFXSource.clip = gameOver;
        SFXSource.Play();
        StartCoroutine(FadeOutBackgroundMusic());
    }

    private IEnumerator FadeOutBackgroundMusic()
    {
        float fadeDuration = 1f;  // Duration to fade out the music
        float startVolume = backgroundMusic.volume;  // Save the current volume

        while (backgroundMusic.volume > 0)
        {
            backgroundMusic.volume -= startVolume * Time.deltaTime / fadeDuration;
            yield return null;
        }

        backgroundMusic.Stop();  // Stop the background music after it fades out
        backgroundMusic.volume = startVolume;  // Reset volume back to the original
    }

    // Function to pause background music
    public void PauseBackgroundMusic()
    {
        if (backgroundMusic.isPlaying)
        {
            backgroundMusicTime = backgroundMusic.time;  // Store the current time of the background music
            backgroundMusic.Pause();  // Pause the music
        }
    }

    // Resume background music from the paused position
    public void ResumeBackgroundMusic()
    {
        if (!backgroundMusic.isPlaying)  // Only resume if the music is not already playing
        {
            backgroundMusic.time = backgroundMusicTime;  // Set the music to where it was paused
            backgroundMusic.Play();  // Play the music from that point
        }
    }

    // Stop background music
    public void StopBackgroundMusic()
    {
        backgroundMusic.Stop();  // Stop the background music
        isBackgroundMusicPlaying = false;  // Mark the music as not playing
    }
        public void PlayPause()
    {
        SFXSource.clip = Pause;
        SFXSource.Play();
    }

 

    // Play sound effects (SFX)

    public void PlayPlayerShoot()
    {
        //SFXSource.clip = playerShoot;
        SFXSource.PlayOneShot(playerShoot);
    }

    public void PlayPlayerHit()
    {
        //SFXSource.clip = playerHit;
        SFXSource.PlayOneShot(playerHit);
    }

    public void PlayPlayerDie()
    {
        //SFXSource.clip = playerDie;
        SFXSource.PlayOneShot(playerDie);
    }
    public void PlayButtonClick()
    {
        SFXSource.PlayOneShot(buttonClick);
    }



}
