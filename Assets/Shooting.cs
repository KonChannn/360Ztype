using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 100f;
    public PlayerMovement playerMovement; 
    public float shootAngleThreshold = 5f;
    void Update()
    {
        if (Input.anyKeyDown)
        {
            TryShoot();
        }
    }

    private void TryShoot()
    {
        // Check if player is aligned with the active word
        if (playerMovement != null && playerMovement.wordManager.HasActiveWord())
        {
            Vector3 targetDirection = playerMovement.wordManager.position - (Vector2)transform.position;

            // Calculate angle difference
            float angleDifference = Vector2.Angle(transform.up, targetDirection);

            if (angleDifference <= shootAngleThreshold)
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
