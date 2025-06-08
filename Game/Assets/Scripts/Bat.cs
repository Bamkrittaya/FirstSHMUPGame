using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
[SerializeField]public float moveSpeed = 5f;  // Speed at which the witch moves
bool canBeDestroyed = false;  // Flag to determine if the witch can be destroyed
private Vector2 pos;
public GameObject deathEffect;

//public AudioManager audioManager;  // Reference to the AudioManager to change background music




void Start()
{
}
    void Update()
    {
       
    }
     void FixedUpdate() // Use FixedUpdate for consistent physics-based movement
    {
        if (transform.position.x < 17f) {
            canBeDestroyed = true;  // Allow the bat to be destroyed if it goes offscreen
        }
        // Make the bat move in a wave pattern
        float sineWave = Mathf.Sin(pos.x);  // Use Time.time to create a continuous wave effect
          // Multiplied by a factor to control wave height (amplitude)
    
        // Move the bat to the left
        pos = transform.position;
        pos.y = pos.y + sineWave *0.05f;
        pos.x -= moveSpeed * Time.fixedDeltaTime;  // Move the bat to the left using fixedDeltaTime


        /*float sin = Mathf.Sin(pos.x);
        pos.y =sin;  // Calculate the sine wave value
        
        pos = transform.position;
        pos.x -= moveSpeed * Time.fixedDeltaTime;  // Move the bat to the left using fixedDeltaTime
        */
        if (pos.x < 0f) {
            Destroy(gameObject);  // Destroy the bat if it goes offscreen
        }

        transform.position = pos;  // Update the bat's position
    }

    

     private void OnTriggerEnter2D(Collider2D other)
    {
        if (!canBeDestroyed) {
            return; 
        } // If the witch can't be destroyed, return

        if (other.CompareTag("Player")) {
            SFManager.PlaySF("batDie"); 
            GameObject effect = Instantiate(deathEffect, transform.position, transform.rotation);
            Destroy(effect, 1.0f);
            Destroy(gameObject);  // Destroy the bat when it collides with the player
            // Optionally, you can decrease the player's health here as well
            //ScoreManager.instance.AddPoint(19);  // Add 19 points to the score

            return;
            
        }

        Heart heart = other.GetComponent<Heart>();  // Get the heart component from the collider
        if (heart != null)
        {
            SFManager.PlaySF("batDie"); 
            GameObject effect = Instantiate(deathEffect, transform.position, transform.rotation);     
            Destroy(effect, 1.0f);
            Destroy(gameObject);
            Destroy(heart.gameObject);
            ScoreManager.instance.AddPoint(50);  // Add 19 points to the score

           
        }
    }
     

}
