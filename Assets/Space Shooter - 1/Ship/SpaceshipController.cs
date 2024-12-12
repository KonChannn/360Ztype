using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    public float speed = 5f; // Kecepatan spaceship

    void Update()
    {
        // Mengambil input dari keyboard
        float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float moveY = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        // Memindahkan spaceship berdasarkan input
        transform.Translate(new Vector3(moveX, moveY, 0));
    }
}
