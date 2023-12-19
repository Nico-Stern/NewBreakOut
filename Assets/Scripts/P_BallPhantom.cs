using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class P_BallPhantom : MonoBehaviour
{
    [SerializeField] private float minY = -5.5f;
    [SerializeField] private float trueMinY = -10.5f;
    [SerializeField] private float maxVelocity = 15f;
    [SerializeField] private P_Ball ball;
    private Rigidbody2D rb;
    
    void Start()
    {
        int rdm = Random.Range(1, 2);
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * 10f;
        
        switch (rdm)
        {
            case 1:
                rb.velocity += Vector2.left * 2f;
                break;
            case 2:
                rb.velocity += Vector2.right * 2f;
                break;
        }
    }

    void Update()
    {
        if (transform.position.y < minY)
        {
            rb.velocity = Vector2.down * 10f;
        }

        if (transform.position.y < trueMinY)
        {
            Destroy(gameObject);
        }
        
        if (rb.velocity.magnitude > maxVelocity)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
        }

        StartCoroutine(Die());
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Brick"))
        { 
            Debug.Log("Hit");
            if (other.gameObject.GetComponent<N_Brick>().life <= 1)
            {
                Destroy(other.gameObject);
                ball.CountScore();
            }
            else
            {
                other.gameObject.GetComponent<N_Brick>().MinusLife();
            }
        }
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(15);
        Destroy(gameObject);
    }
}
