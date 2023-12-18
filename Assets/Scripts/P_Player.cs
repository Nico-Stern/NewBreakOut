using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Player : MonoBehaviour
{
    [SerializeField] private float playerVelocity = 1f;
    private Vector3 playerPosition;
    private float boundary = 6.75f;
    void Start()
    {
        playerPosition = transform.position;
    }

    
    void FixedUpdate()
    {
        playerPosition.x += Input.GetAxis("Horizontal") * playerVelocity;
        transform.position = playerPosition;
        
    }

    private void Update()
    {
        if (playerPosition.x < -boundary)
        {
            transform.position = new Vector3(-boundary, playerPosition.y, playerPosition.z);
        }
        if (playerPosition.x > boundary)
        {
            transform.position = new Vector3(boundary, playerPosition.y, playerPosition.z);
        }
        
        
    }
}
