using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public Vector2 direction = new Vector2(1, 0); // Direction in which the heart moves (right)
    public float speed = 5;  // Adjusted speed to be more reasonable
    private float lifeTime = 4.0f;  // Time until the heart is destroyed

    void Start()
    {
        Destroy(gameObject, lifeTime); // Destroy the heart after a set time
    }

    void Update()
    {
        MoveHeart();
    }

    private void MoveHeart()
    {
        // Move the heart in the direction specified
        transform.Translate(direction * speed * Time.deltaTime); // This uses the current direction and speed for movement
    }
    
}
