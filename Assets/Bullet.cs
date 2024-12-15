using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject explosionEffect;
    void OnCollisionEnter2D(Collision2D collision)
    {
        
        // Destroy the bullet when it collides with something
        // Instantiate an explosion effect
        // GameObject explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);
        // Destroy(explosion, 5f);
        Destroy(gameObject);
    }
}
