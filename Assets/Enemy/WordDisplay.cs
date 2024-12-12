using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordDisplay : MonoBehaviour
{
    public TextMeshProUGUI text;
    public float speed = 1f; // Movement speed toward the player

    private Vector3 targetPosition;
    public void SetWord(string word)
    {
        text.text = word;
    }

    public void RemoveWord()
    {
        Destroy(gameObject);
    }

    public void RemoveLetter()
    {
        text.text = text.text.Remove(0, 1);
        text.color = Color.red;
    }

    private void Update()
    {   

        // Set target position to the middle of the screen dynamically
        // Get the center of the screen in world space
        targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, Camera.main.nearClipPlane));
        
        // Ensure we are working in 2D space by setting z to 0
        targetPosition.z = 0;

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed/10);
    }
}
