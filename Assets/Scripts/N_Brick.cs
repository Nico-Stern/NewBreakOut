using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

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

    void SetWhichPower()
    {
        int rdm = Random.Range(0, 10);
        if(rdm == 0)
        {
            //Leben
        }
        else if(rdm >= 1&&rdm<5)
        {
            //Lava
        }
        else if(rdm >= 6)
        {
            //Multiball
        }
    }

    private void OnDestroy()
    {
        GameObject Spawner = GameObject.FindGameObjectWithTag("Spawner");
        print(Spawner);
        int count=Spawner.GetComponent<N_BrickSpawner>().AllBricks.Count;
        for(int i=0; i<count; i++)
        {
            if (Spawner.GetComponent<N_BrickSpawner>().AllBricks[i] == this.gameObject)
            {
                Spawner.GetComponent<N_BrickSpawner>().AllBricks.RemoveAt(i);
                return;
            }
        }
    }

    public void SetBrickIntoTrigger(bool a)
    {
        gameObject.GetComponent<BoxCollider2D>().isTrigger = a;
    }
}
public enum Brick
{
    Normal,
    PowerUp,
    MoreHit,
}
