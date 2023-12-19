using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore;
using UnityEngine.UI;

public class P_Ball : MonoBehaviour
{
    [SerializeField] private float minY = -5.5f;
    [SerializeField] private float maxVelocity = 15f;
    private Rigidbody2D rb;
    private int score;
    private int lives = 3;
    public Text scoreTxt;
    public GameObject[] livesImage;
    [SerializeField] private GameObject ballPhantom;
    private Vector3 BallReset;
    private bool ballIsActive;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //rb.velocity = Vector2.down * 10f;
        BallReset = new Vector3(0.0f, -1f, 0.0f);
        ballIsActive = false;
    }

    private void Update()
    {
        if (ballIsActive == true)
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
                    lives--;
                    livesImage[lives].SetActive(false);
                }
            
            }

            if (rb.velocity.magnitude > maxVelocity)
            {
                rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
            }
        }
        

        if (Input.GetButtonDown("Jump"))
        {
            if (ballIsActive == false)
            {
                rb.velocity = Vector2.down * 10f;
            }
            ballIsActive = true;
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

        if (col.gameObject.CompareTag("PowerUp"))
        {
            col.gameObject.GetComponent<P_PowerUps>().UsePowerUp();
            Destroy(col.gameObject);
        }
    }

    void GameOver()
    {
        Time.timeScale = 0;
    }

    public void addLive()
    {
        Debug.Log("addLive");
        lives++;
        Debug.Log(lives);
        livesImage[lives].SetActive(true);
    }

    public void split()
    {
        var phantom = Instantiate(ballPhantom, transform.position, quaternion.identity);
        Debug.Log("split");
    }

    public void lava()
    {
        Debug.Log("lava");
    }
}
