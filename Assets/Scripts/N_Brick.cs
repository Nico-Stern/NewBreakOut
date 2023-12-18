using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N_Brick : MonoBehaviour
{
    public Brick WhatBrick;
    [SerializeField] Color[] BrickColor;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ChangeColor()
    {
        switch (WhatBrick)
        {
            case Brick.Normal:
                GetComponent<SpriteRenderer>().color = BrickColor[0];
                break;
            case Brick.MoreHit:
                GetComponent<SpriteRenderer>().color = BrickColor[1];
                break;
            case Brick.PowerUp:
                GetComponent<SpriteRenderer>().color = BrickColor[2];
                break;
        }
    }
}
public enum Brick
{
    Normal,
    PowerUp,
    MoreHit,
}
