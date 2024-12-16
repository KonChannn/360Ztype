using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Update()
    {
        // Check if the bullet is outside the camera's view (canvas)
        if (!IsInCameraView())
        {
            Destroy(gameObject); // Destroy the bullet if it's outside the canvas
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        
        // Destroy the bullet when it collides with something
        // Instantiate an explosion effect
        // GameObject explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);
        // Destroy(explosion, 5f);
        Destroy(gameObject);
    }

    bool IsInCameraView()
    {
        // Convert the bullet's position to screen space
        Vector3 bulletScreenPos = Camera.main.WorldToScreenPoint(transform.position);

        // Check if the bullet is within the screen bounds (canvas)
        return bulletScreenPos.x >= 0 && bulletScreenPos.x <= Screen.width && bulletScreenPos.y >= 0 && bulletScreenPos.y <= Screen.height;
    }
}
