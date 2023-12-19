using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class N_Brick : MonoBehaviour
{
    public Brick WhatBrick;
    [SerializeField] Sprite[] BrickColor;
    public int Reihe;
    public int life=1;
    [SerializeField] GameObject PowerUp;

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
                GetComponent<SpriteRenderer>().sprite = BrickColor[0];
                break;
            case Brick.MoreHit:
                GetComponent<SpriteRenderer>().sprite = BrickColor[1];
                life = 3;
                break;
            case Brick.PowerUp:
                GetComponent<SpriteRenderer>().sprite = BrickColor[2];
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject Spawner = GameObject.FindGameObjectWithTag("Spawner");
        print(Spawner);
        int count = 0;
        try
        {
            count = Spawner.GetComponent<N_BrickSpawner>().AllBricks.Count;
        }
        catch
        {

        }
        for (int i = 0; i < count; i++)
        {
            if (Spawner.GetComponent<N_BrickSpawner>().AllBricks[i] == this.gameObject)
            {
                if (life <= 1)
                {
                    Spawner.GetComponent<N_BrickSpawner>().AllBricks.RemoveAt(i);
                }
                break;
            }
        }
        print("try");
        try
        {
            Spawner.GetComponent<N_BrickSpawner>().CheckLastBricks();
        }
        catch
        {

        }
        if (WhatBrick == Brick.PowerUp)
        {
            Instantiate(PowerUp, transform.position, Quaternion.identity);
        }

        GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, 0.25f);
    }

    public void SetBrickIntoTrigger(bool a)
    {
        gameObject.GetComponent<BoxCollider2D>().isTrigger = a;
    }

    public void MinusLife()
    {
        life--;
    }
}
public enum Brick
{
    Normal,
    PowerUp,
    MoreHit,
}
