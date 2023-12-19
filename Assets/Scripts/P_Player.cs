using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Player : MonoBehaviour
{
    [SerializeField] private float playerVelocity = 10f;
    private float playerMov;    
    private float boundary = 7f;
    
    void Update()
    {
        playerMov = Input.GetAxis("Horizontal");
        if ((playerMov > 0 && transform.position.x < boundary) || (playerMov < 0 && transform.position.x > -boundary))
        {
            transform.position += Vector3.right * playerMov * playerVelocity * Time.deltaTime;
        }
    }
}
