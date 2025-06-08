using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Witch : MonoBehaviour
{
    public float moveSpeed = 0.1f;  // Speed at which the witch moves
    bool canBeDestroyed = false;  // Flag to determine if the witch can be destroyed
    [SerializeField] private GameObject Poison;  // Reference to the heart prefab
    private Vector2 pos;
    public bool autoShoot = true; // Flag to determine if the witch should automatically shoot
    public float shootInterval = 1f;  // Time between shots
    public float shootDelay = 0f;  // Delay between shots
    private float shootTimer = 0.0f;  // Time until the witch shoots
    private float delayTimer = 0.0f;  // Time until the witch shoots
    private int shotCount = 0;  // Number of shots fired
    private float postShootDelay = 3f;  // Delay after shooting
    private float originalMoveSpeed;  // Store the original move speed
    private int health = 2;  // Witch's health (starts at 2)

    public GameObject deathEffect;
    //public AudioManager audioManager;  // Reference to the AudioManager to change background music




 // Reference to the heart prefab
    void Start()
    {
          // Store the original move speed
    }
    void Update()
    {
        if (transform.position.x < 17f) {
            canBeDestroyed = true;  // Destroy the witch if it goes offscreen

        }
        if (autoShoot)
        {
            if (delayTimer >= shootDelay)
            {
                if (shootTimer >= shootInterval)
                {
                    Shoot();  // Call the Shoot method
                    shootTimer = 0.0f;  // Reset the shoot timer

                    shotCount++;  // Increment shot count after each shot

                    if (shotCount == 1)  // First shot fired, stop movement for 3-4 shots
                    {
                        originalMoveSpeed = moveSpeed;  // Store the original move speed
                        moveSpeed = 0f;  // Stop the witch from moving
                        postShootDelay = 3f;  // Stop for 3 seconds
                    }

                    if (shotCount >= 4)  // After 3-4 shots, resume moving
                    {
                        moveSpeed = originalMoveSpeed ;// Resume the normal movement speed
                        //shotCount = 0;  // Reset shot count to start the cycle again
                    }
                }
                else
                {
                    shootTimer += Time.deltaTime;  // Increment the shoot timer
                }
            }
            else
            {
                delayTimer += Time.deltaTime;  // Increment the delay timer before shooting
            }

            if (postShootDelay > 0f)  // Decrease post-shoot delay after the first shot
            {
                postShootDelay -= Time.deltaTime;
                if (postShootDelay <= 0f)
                {
                    moveSpeed = 0.1f;  // Resume movement after delay
                }
            }
        }
    }
    

    
    private void FixedUpdate(){
        pos = transform.position;
        pos.x -= moveSpeed * Time.fixedDeltaTime;  // Move the witch to the left

        if (pos.x < 0f) {
            Destroy(gameObject);
            GameObject player = GameObject.FindGameObjectWithTag("Player");  // Find the player by tag
            if (player != null)
            {
                Player playerScript = player.GetComponent<Player>();
                if (playerScript != null)
                {
                    playerScript.DecreaseHealth(1);  // Decrease health by 1
                }
            }  // Destroy the witch if it goes offscreen
        }
        //pos.y = Mathf.Clamp(Random.Range(1f, 9f), 1f, 9f);
        transform.position = pos;  // Update the witch's position
    }
    
   private void Shoot()
    {
        // Shoot a Poison projectile
        Instantiate(Poison, transform.position, Quaternion.identity);
        Poison.GetComponent<Poison>().direction = Vector2.left;  // Set the heart's direction to the left
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!canBeDestroyed) {

            return; 
            
        } // If the witch can't be destroyed, return

        Heart heart = other.GetComponent<Heart>();  // Get the heart component from the collider
        if (heart != null)
        {
            health-=1;

        if (health <= 0)
        {
            SFManager.PlaySF("witchGood");  // Play sound effect for witch death
            // If health reaches 0, destroy the witch
            GameObject effect = Instantiate(deathEffect, transform.position, transform.rotation);
            Destroy(effect, 1.9f);
            Destroy(gameObject);  // Destroy the witch

            // Check if audioManager is not null before using it
            /*if (audioManager != null)
            {
                audioManager.PlayWitchGoodSound();  // Play sound if audioManager is assigned
            }*/

            ScoreManager.instance.AddPoint(100);  // Add 100 points to the score
        }

        Destroy(heart.gameObject);  // Destroy the heart
        }
    }
        
 }