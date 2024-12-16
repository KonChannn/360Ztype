using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordDisplay : MonoBehaviour
{
    public TextMeshProUGUI text;
    [SerializeField] public float speed; // Movement speed toward the player
    private Vector3 targetPosition;
    private int bulletHitCount;
    private int wordLength;
    private ExplosionFx explosionFx;
    public GameObject explosionPrefab; // Explosion prefab
    
    private void Awake()
    {
        // Initialize the explosion effect
        if (explosionPrefab != null)
        {
            explosionFx = gameObject.AddComponent<ExplosionFx>();
            explosionFx.explosionEffect = explosionPrefab;
        }
        else
        {
            Debug.LogError("Explosion prefab is not assigned in the Inspector!");
        }
    }
    public int BulletHitCount
    {
        get { return bulletHitCount; }
    }
    public int WordLength
    {
        get { return wordLength; }
    }
    // This method will be triggered when a bullet/player collides with the word
    void OnTriggerEnter2D(Collider2D other)
    {
        // Ensure the object colliding with the word has the "Bullet" tag
        if (other.CompareTag("Bullet"))
        {
            // Increment the bullet hit count
            bulletHitCount++; 

            // Play the explosion effect
            explosionFx.SpawnExplosion();

            Destroy(other.gameObject);

            CheckAndRemoveWord();

        }
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);      
        }
    }


    public void SetWord(string word)
    {
        text.text = word;
        wordLength = word.Length;
        // Debug.Log("Word: " + text.text);
        // Debug.Log("Word length: " + text.text.Length);
    }

    // Remove the word from the display if conditions are met
    public void CheckAndRemoveWord()
    {
        if (bulletHitCount >= wordLength-1)
        {
            RemoveWord(); // Call RemoveWord when the condition is met
        }
    }
    private void RemoveWord()
    {
        
        Destroy(gameObject); // Destroy the word game object
    }

    public void RemoveLetter()
    {
        text.text = text.text.Remove(0, 1);
        text.color = Color.red;
    }

    private void Update()
    {
        // Set target position to the middle of the screen dynamically
        targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, Camera.main.nearClipPlane));
        
        // Ensure we are working in 2D space by setting z to 0
        targetPosition.z = 0;

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Debug.Log(text.text);
    }
}
