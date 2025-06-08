using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private GameObject HeartShape;  // Reference to the heart prefab
    private GameObject currentHeart;  // Store the current heart object
    private float fireTime;  // Used to manage the fire rate
    [SerializeField] private float health = 3f;
    public GameObject deathEffect;
    public GameObject hurtEffect;
    public Animator animator;
    private float hurtAnimationDuration = 1f; // Set the duration of the hurt animation
    public ScoreManager scoreManager;  // Assign in Inspector or programmatically
    public GameOver gameOverScript;
    // Add references to the UI Heart images
    public Image[] healthHearts;  // Array to hold heart UI elements
    //private int maxHealth = 3;    // Maximum health (3 hearts)
    public int score = 0;  // Player's score

    public AudioManager audioManager;  // Reference to the AudioManager to change background music

// Player.cs


    void Start()
    {
        
        animator = GetComponent<Animator>(); // Get the Animator component

    }

    void Update()
    {
        MovePlayer();  // Call MovePlayer to handle movement
        Shoot();       // Call Shoot to handle firing projectiles
    }

    private void MovePlayer()
    {
        Vector2 pos = transform.position;

        float moveAmount = moveSpeed * Time.fixedDeltaTime;
        Vector2 move = Vector2.zero;


        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) moveAmount *= 2;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) move.y += moveAmount; 
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) move.y -= moveAmount; 
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) move.x -= moveAmount; 
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) move.x += moveAmount;

        // Fixing diagonal movement using SpeedMove function
        move = SpeedMove(move, moveAmount);

        pos += move;

        // Set boundaries for the player's position
        pos.x = Mathf.Clamp(pos.x, 1.5f, 16.5f);  // Clamp the x position between 1f and 17f
        pos.y = Mathf.Clamp(pos.y, 1f, 7.5f);   // Clamp the y position between 1f and 9f

        transform.position = pos;  // Update player's position
    }

    private Vector2 SpeedMove(Vector2 move, float moveAmount)
    {
        // Calculate the movement magnitude (for diagonal adjustment)
        float moveMagnitude = Mathf.Sqrt(move.x * move.x + move.y * move.y);

        // Normalize diagonal movement if it exceeds normal speed
        if (moveMagnitude > moveAmount)
        {
            float ratio = moveAmount / moveMagnitude;
            move *= ratio;
        }

        return move;  // Return adjusted movement
    }

    private void Shoot()
    {
        // Only shoot once when space is pressed and there's no existing heart
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > fireTime)
        {
            Vector2 shootPosition = transform.position;  // Adjust the 1.0f to the desired distance
            //Debug.Log("Shoot Position: " + shootPosition);

            Instantiate(HeartShape, shootPosition, Quaternion.identity);
            // Optional: Add sound effects or animations here when shooting
            audioManager.PlayPlayerShoot();  // Play shooting sound
        }
    }

    public void DecreaseHealth(int amount)
    {
        animator.SetTrigger("IsHurt");
        audioManager.PlayPlayerHit();
        health -= amount;
        Debug.Log("Player's health: " + health);
        // Call Reset to Walking after the hurt animation duration
        // Update the health bar UI (hearts)
        UpdateHealthBar();

        Invoke("ResetToWalk", hurtAnimationDuration);
            

        if (health <= 0)
        {
            GameObject effect = Instantiate(deathEffect, transform.position, transform.rotation);
            Destroy(effect, 1.0f);
            Destroy(this.gameObject);  // Destroy the player if health reaches 0
            
            audioManager.PlayPlayerDie();
            // Get the score from the ScoreManager
            int score = scoreManager.GetScore();
            gameOverScript.ShowGameOver(score);
        }
    }

    private void UpdateHealthBar()
    {
        // Loop through the hearts and enable/disable based on current health
        for (int i = 0; i < healthHearts.Length; i++)
        {
            if (i < health)
            {
                healthHearts[i].enabled = true;  // Show the heart if health is greater than i
            }
            else
            {
                healthHearts[i].enabled = false; // Hide the heart if health is less than i
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Poison"))
    {
        // Handle Poison collision (player hit by poison)
        animator.SetTrigger("IsHurt");
        audioManager.PlayPlayerHit();
        health -= 1;
        Debug.Log("Player hit by poison");

        UpdateHealthBar();
        Invoke("ResetToWalk", hurtAnimationDuration);

        if (health <= 0)
        {
            GameObject effect = Instantiate(deathEffect, transform.position, transform.rotation);
            Destroy(effect, 1.0f);
            Destroy(this.gameObject);  // Destroy player on death
            audioManager.PlayPlayerDie();

            int score = scoreManager.GetScore();
            gameOverScript.ShowGameOver(score);  // Pass the score to ShowGameOver method
        }
    }
    
    if (other.CompareTag("Bat"))
    {
        // Handle Bat collision
        animator.SetTrigger("IsHurt");
        audioManager.PlayPlayerHit();
        health -= 1;
        Debug.Log("Player hit by bat");

        UpdateHealthBar();
        Invoke("ResetToWalk", hurtAnimationDuration);

        if (health <= 0)
        {
            GameObject effect = Instantiate(deathEffect, transform.position, transform.rotation);
            Destroy(effect, 1.0f);
            Destroy(this.gameObject);  // Destroy player on death
            audioManager.PlayPlayerDie();

            int score = scoreManager.GetScore();
            gameOverScript.ShowGameOver(score);  // Pass the score to ShowGameOver method
        }
    }

    if (other.CompareTag("Witch"))
    {
        // Handle Witch collision
        animator.SetTrigger("IsHurt");
        audioManager.PlayPlayerHit();
        health -= 1;
        Debug.Log("Player hit by witch");

        UpdateHealthBar();
        Invoke("ResetToWalk", hurtAnimationDuration);

        if (health <= 0)
        {
            GameObject effect = Instantiate(deathEffect, transform.position, transform.rotation);
            Destroy(effect, 1.0f);
            Destroy(this.gameObject);  // Destroy player on death
            audioManager.PlayPlayerDie();

            int score = scoreManager.GetScore();
            gameOverScript.ShowGameOver(score);  // Pass the score to ShowGameOver method
        }
    }
}


     private void ResetToWalk()
    {
        animator.SetTrigger("IsWalking");  // Assuming "IsWalking" is the trigger for the walk animation
    }

}
