using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public PlayerManager playerMovement; 
    public WordManager wordManager;
    public float bulletForce = 100f;
    public float shootAngleThreshold = 5f;
    void Update()
    {
        if (Input.anyKeyDown)
        {
            Word activeWord = wordManager.ActiveWord;
            char typedLetter = GetTypedLetter();

            if(activeWord.GetNextLetter() == typedLetter)
            {
                TryShoot();
            }

        }
    }

     private char GetTypedLetter()
    {
        // You could add more sophisticated checks depending on your input method
        foreach (char c in Input.inputString)
        {
            return c; // Return the first character typed
        }
        return '\0'; // Return null character if no key is pressed
    }

    private void TryShoot()
    {
        // Check if player is aligned with the active word
        if (playerMovement != null && playerMovement.wordManager.HasActiveWord)
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
