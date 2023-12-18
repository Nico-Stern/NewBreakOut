using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore;

public class P_Ball : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private int BallIsActive;
    private Vector3 BallPosition;
    private Vector2 BallInitalForce;
    private float OriginY;
    private Rigidbody2D rb;
    
    void Start()
    {
        BallIsActive = 0;
        BallPosition = transform.position;
        OriginY = transform.position.y;
        BallInitalForce = new Vector2(100f, 300f);
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (BallIsActive == 0)
            {
                rb.AddForce(BallInitalForce);
                BallIsActive = 1;
            }
        }

        if (BallIsActive == 0 && player != null)
        {
            BallPosition.x = player.transform.position.x;
            transform.position = BallPosition;
        }
    }
}
