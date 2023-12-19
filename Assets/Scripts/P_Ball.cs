using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore;
using UnityEngine.UI;

public class P_Ball : MonoBehaviour
{
    [SerializeField] private float minY = -5.5f;
    [SerializeField] private float maxVelocity = 15f;
    private Rigidbody2D rb;
    private int score = 0;
    private int lives = 3;
    public Text scoreTxt;
    public GameObject[] livesImage;
    private Vector3 BallReset;

    private void Start()
    {
        Time.timeScale = 1;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * 10f;
        BallReset = new Vector3(0.0f, -1f, 0.0f);
        GetComponent<P_Player>();
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
                transform.position = BallReset;
                rb.velocity = Vector2.down * 10f;
                //rb.velocity = Vector2.zero;
                lives--;
                livesImage[lives].SetActive(false);
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
            scoreTxt.text = score.ToString("00000");
        }
    }

    void GameOver()
    {
        Time.timeScale = 0;
        SceneManager.LoadScene("GameOver");
    }
}
