using UnityEngine;

public class Poison : MonoBehaviour
{
    public Vector2 direction = new Vector2(-1, 0); // Direction in which the heart moves (right)
    public float speed = 5;  // Adjusted speed to be more reasonable
    private float lifeTime = 5.0f;  // Time until the heart is destroyed
   

    void Start()
    {
        Destroy(gameObject, lifeTime); // Destroy the heart after a set time
    }

    void Update()
    {
        MovePoison();
    }

    private void MovePoison()
    {
        // Move the heart in the direction specified
        transform.Translate(direction * speed * Time.deltaTime); // This uses the current direction and speed for movement
    }

    private void OnTriggerEnter2D(Collider2D other)
{
            if (other.CompareTag("Player")) {
            //GameObject effect = Instantiate(deathEffect, transform.position, transform.rotation);
            //Destroy(effect, 1.0f);
            Destroy(gameObject);  // Destroy the bat when it collides with the player
            // Optionally, you can decrease the player's health here as well
            return;
        }
}
   
}
