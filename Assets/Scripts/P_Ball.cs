using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore;

public class P_Ball : MonoBehaviour
{
    [SerializeField] private float minY = -5.5f;
    [SerializeField] private float maxVelocity = 15f;
    private Rigidbody2D rb;
    private int score = 0;
    private int lives = 5;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * 10f;
    }

    private void Update()
    {
        if (transform.position.y < minY)
        {
            if (lives <= 0)
            {
                GameOver();
            }
            else
            {
                transform.position = Vector3.zero;
                rb.velocity = Vector2.down * 10f;
                //rb.velocity = Vector2.zero;
                lives--;
            }
            
        }

        if (rb.velocity.magnitude > maxVelocity)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Brick"))
        {
            Destroy(col.gameObject);
            score += 10;
        }
    }

    void GameOver()
    {
        Time.timeScale = 0;
    }
}
