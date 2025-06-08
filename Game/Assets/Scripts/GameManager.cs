using System.Collections;  
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject batPrefab;  // Reference to Bat prefab
    [SerializeField] private GameObject witchPrefab; // Reference to Witch prefab
    [SerializeField] private float spawnInterval = 1.5f;  // Time between enemy spawns
    [SerializeField] private float startDelay = 2.5f; // Delay before spawning starts

    private bool isGameOver = false;
    // GameManager.cs



    void Start()
    {
        // Start spawning enemies with a delay before starting
        StartCoroutine(StartSpawnWithDelay());
    }

    IEnumerator StartSpawnWithDelay()
    {
        // Wait for the specified delay before starting the spawning
        yield return new WaitForSeconds(startDelay);
        // After the delay, start spawning enemies
        StartCoroutine(SpawnEnemies());
    }

    // Coroutine to spawn enemies at regular intervals
    IEnumerator SpawnEnemies()
    {
        while (!isGameOver) // Continue until the game is over
        {
            // Instantiate the Bat and Witch at random positions within the spawn area
            if (Random.value > 0.5f)
            {
                Instantiate(batPrefab, new Vector2(Random.Range(25f, 40f), Random.Range(3f,7.5f)), Quaternion.identity);
                Instantiate(batPrefab, new Vector2(Random.Range(25f, 40f), Random.Range(3f,7.5f)), Quaternion.identity);
                Instantiate(batPrefab, new Vector2(Random.Range(25f, 40f), Random.Range(3f,7.5f)), Quaternion.identity);
            }
            else
            {
                Instantiate(witchPrefab, new Vector2(Random.Range(20f, 24f), Random.Range(1.4f,7.5f)), Quaternion.identity);
            }

            // Wait for the next spawn interval
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    // Method to stop the spawning when the player dies
    public void StopSpawning()
    {
        isGameOver = true;
    }

}
