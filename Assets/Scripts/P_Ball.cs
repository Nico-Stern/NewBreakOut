using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore;

public class P_Ball : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private int ballIsActive;
    private Vector3 ballPosition;
    private Vector2 ballPosV2;
    private Vector2 ballInitalForce;
    private Vector2 playerOffset;
    private Vector2 playerSize;
    private Vector2 distance;
    private BoxCollider2D p_collider;
    //private float OriginY;
    private Rigidbody2D rb;
    
    void Start()
    {
        p_collider = player.GetComponent<BoxCollider2D>();
        p_collider.offset = playerOffset;
        p_collider.size = playerSize;
        ballIsActive = 0;
        ballPosition = transform.position;
        //OriginY = transform.position.y;
        playerSize = new Vector2(100f, 300f);
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (ballIsActive == 0)
            {
                rb.AddForce(ballInitalForce);
                ballIsActive = 1;
            }
        }

        if (ballIsActive == 0 && player != null)
        {
            ballPosition.x = player.transform.position.x;
            transform.position = ballPosition;
            ballPosV2 = new Vector2(transform.position.x, transform.position.y);
        }
    }

    void HitPlayer()
    {
        //Vector2.Distance(ballPosV2, playerOffset) = distance;
    }
    
}
