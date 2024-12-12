using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpawner : MonoBehaviour
{
    public GameObject wordPrefab;
    public Transform wordCanvas;

    public WordDisplay SpawnWord()
    {
        // Randomly choose a side: 0 = Top, 1 = Bottom, 2 = Left, 3 = Right
        int side = Random.Range(0, 4);
        Vector3 randomPosition = Vector3.zero;

        switch (side)
        {
            case 0: // Top
                randomPosition = new Vector3(Random.Range(-1200f, 1200f), 800f, 0);
                break;
            case 1: // Bottom
                randomPosition = new Vector3(Random.Range(-1200f, 1200f), -800f, 0);
                break;
            case 2: // Left
                randomPosition = new Vector3(-1200f, Random.Range(-800f, 800f), 0);
                break;
            case 3: // Right
                randomPosition = new Vector3(1200f, Random.Range(-800f, 800f), 0);
                break;
        }

        // Spawn the word object
        GameObject wordObj = Instantiate(wordPrefab, randomPosition, Quaternion.identity, wordCanvas);
        WordDisplay wordDisplay = wordObj.GetComponent<WordDisplay>();

        return wordDisplay;
    }
}
