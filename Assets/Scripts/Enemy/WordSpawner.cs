using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpawner : MonoBehaviour
{
    
    public GameObject wordPrefab;
    public RectTransform wordCanvas; // Ensure this is a RectTransform

    public WordDisplay SpawnWord()
    {
        // Log canvas dimensions
        float canvasWidth = wordCanvas.rect.width;
        float canvasHeight = wordCanvas.rect.height;
        // Debug.Log($"Canvas Width: {canvasWidth}, Canvas Height: {canvasHeight}");

        // Randomly choose a side: 0 = Top, 1 = Bottom, 2 = Left, 3 = Right
        int side = Random.Range(0, 4);
        Vector2 randomPosition = Vector2.zero;

        switch (side)
        {
            case 0: // Top
                randomPosition = new Vector2(
                    Random.Range(-canvasWidth / 2, canvasWidth / 2), // Random X within canvas width
                    canvasHeight / 2                                // Y at the top
                );
                break;
            case 1: // Bottom
                randomPosition = new Vector2(
                    Random.Range(-canvasWidth / 2, canvasWidth / 2), // Random X within canvas width
                    -canvasHeight / 2                               // Y at the bottom
                );
                break;
            case 2: // Left
                randomPosition = new Vector2(
                    -canvasWidth / 2,                              // X at the left
                    Random.Range(-canvasHeight / 2, canvasHeight / 2) // Random Y within canvas height
                );
                break;
            case 3: // Right
                randomPosition = new Vector2(
                    canvasWidth / 2,                               // X at the right
                    Random.Range(-canvasHeight / 2, canvasHeight / 2) // Random Y within canvas height
                );
                break;
        }

        // Convert the local position to world space for instantiation
        Vector3 spawnPosition = wordCanvas.TransformPoint(randomPosition);

        // Spawn the word object
        GameObject wordObj = Instantiate(wordPrefab, spawnPosition, Quaternion.identity, wordCanvas);
        WordDisplay wordDisplay = wordObj.GetComponent<WordDisplay>();

        return wordDisplay;
    }
}
