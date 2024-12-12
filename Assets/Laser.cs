using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 20f;
    public SpriteRenderer laserSprite; // Reference untuk sprite laser
    public float laserLifetime = 1f; // Berapa lama laser bertahan
    
    private Transform target;
    private Vector3 targetLastPosition;
    private float timer;
    
    public void SetTarget(Transform wordTransform)
    {
        target = wordTransform;
        targetLastPosition = target.position;
        timer = 0f;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= laserLifetime)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 targetPos = target != null ? target.position : targetLastPosition;
        
        // Bergerak ke arah target
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        
        // Rotasi laser menghadap target
        Vector3 direction = (targetPos - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        
        // Atur skala laser berdasarkan jarak ke target
        float distance = Vector3.Distance(transform.position, targetPos);
        transform.localScale = new Vector3(distance, transform.localScale.y, 1f);
        
        if (Vector3.Distance(transform.position, targetPos) < 0.1f || target == null)
        {
            Destroy(gameObject);
        }
    }
}