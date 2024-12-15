using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public WordManager wordManager; // Reference to the WordManager
    
    [System.Serializable]
    public class Wave
    {
        public string name; // Name of the wave
        public int count; // Number of words in the wave
        public float rate; // Time interval between word spawns
    }

    public Wave[] waves; // Array of waves
    private int currentWaveIndex = 0; // Current wave index
    private bool isWaveInProgress = false;

    public float timeBetweenWaves = 5f; // Time before the next wave starts
    private float waveCountdown; // Countdown timer for the next wave

    private void Start()
    {
        waveCountdown = timeBetweenWaves;
    }

    private void Update()
    {
        // Check if there are remaining waves and the current wave is complete
        if (!isWaveInProgress && wordManager.words.Count == 0 && currentWaveIndex < waves.Length)
        {
            waveCountdown -= Time.deltaTime;

            if (waveCountdown <= 0f)
            {
                StartCoroutine(StartWave());
                waveCountdown = timeBetweenWaves; // Reset the countdown for the next wave
            }
        }
    }

    
    private IEnumerator StartWave()
    {
        isWaveInProgress = true;

        Wave currentWave = waves[currentWaveIndex];
        Debug.Log($"Starting Wave: {currentWave.name}");

        // Spawn all words in the current wave
        for (int i = 0; i < currentWave.count; i++)
        {
            wordManager.AddWord(); // Spawn a new word via WordManager
            yield return new WaitForSeconds(1f / currentWave.rate); // Wait based on the rate
        }

        isWaveInProgress = false;

        // Progress to the next wave
        if (currentWaveIndex < waves.Length - 1)
        {
            currentWaveIndex++;
        }
        else
        {
            Debug.Log("All waves completed!");
        }
    }
}
