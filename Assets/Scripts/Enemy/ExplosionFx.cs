using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ExplosionFx : MonoBehaviour
{
    public GameObject explosionEffect; // Explosion prefab
    public float explosionRadius = 1f; // Maximum radius for the explosion offset
    public void SpawnExplosion()
    {
        // Calculate a random position near the current position
        Vector3 randomOffset = new Vector3(
            Random.Range(-explosionRadius, explosionRadius), // Random x offset
            Random.Range(-explosionRadius, explosionRadius), // Random y offset
            0 // Assuming 2D (z remains 0)
        );

        // Final explosion position
        Vector3 explosionPosition = transform.position + randomOffset;

        // Instantiate the explosion effect
        GameObject explosion = Instantiate(explosionEffect, explosionPosition, Quaternion.identity);

        // Optionally, destroy the explosion after a short delay
        Destroy(explosion, 2f); // Adjust the lifetime of the explosion as needed
    }

}
