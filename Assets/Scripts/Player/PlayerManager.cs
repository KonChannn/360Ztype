using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Rigidbody2D rb; // Reference to the Rigidbody2D for the player
    public WordManager wordManager; // Reference to the WordManager
    public float rotationSpeed = 5f; // Rotation speed for smooth rotation
    public GameOverDisplay gameOverDisplay;

    void OnTriggerEnter2D(Collider2D other)
    {   
        // Debug.Log($"Collided with: {collision.gameObject.name}, Tag: {collision.gameObject.tag}");
        // Destroy the player when it collides with tag "Enemy"
        if (other.CompareTag("Enemy"))
        {
            // Debug.Log(gameOver.IsGameOver);
            // Debug.Log("Game Over!");
            Time.timeScale = 0f;
            gameOverDisplay.Setup();
            // gameOver.IsGameOver = true;
            // Destroy(other.gameObject);
        }
    }
    void Update()
    {
        if (wordManager != null && wordManager.HasActiveWord)
        {
            // Get the position of the active word
            Vector3 targetPosition = wordManager.position;

            // Calculate the direction from the player to the active word
            Vector3 direction = targetPosition - transform.position;

            // Ensure direction is in 2D by setting z to 0
            // direction.z = 0f;

            // Calculate the rotation angle
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

            // Smoothly rotate towards the target
            Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // Debugging
            // Debug.Log($"Direction: {direction}, Angle: {angle}");
        }
    }
}
