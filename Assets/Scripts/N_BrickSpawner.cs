using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class N_BrickSpawner : MonoBehaviour
{
    [SerializeField] bool BricksEqaulsOnX;
    [SerializeField] bool BricksEqaulsOnY;
    [SerializeField] int BricksX;
    [SerializeField] Brick[] BricksY;
    [SerializeField] float BrickOffset;
    [SerializeField] GameObject BrickPrehab;
    Vector3 StartPosition;
    public List<GameObject> AllBricks;
    [SerializeField] List<GameObject> BricksWithOutPowerUp;
    [SerializeField] int PowerUp;

    void Start()
    {
        StartPosition = new Vector3(0, 4.5f+BrickOffset/4, 0);
        if (BricksX%2==0)
        {
            StartPosition.x += ((BrickPrehab.transform.localScale.x + BrickOffset) / 2);
        }
        StartPosition.x -= (BricksX / 2) * (BrickPrehab.transform.localScale.x + BrickOffset);
        this.transform.position = StartPosition;
        SpawnBricks(BricksY.Length);
        BricksY[0] = Brick.Normal;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.N))
        {
            SetAllBricksDown();
            SpawnBricks(1);
        }
    }

    void SetAllBricksDown()
    {
        for(int i = 0; i < AllBricks.Count; i++)
        {
            AllBricks[i].GetComponent<N_Brick>().Reihe++;
            AllBricks[i].transform.position = new Vector3 (AllBricks[i].transform.position.x, AllBricks[i].transform.position.y- (BrickPrehab.transform.localScale.y ), 0);
        }
    }

    public void CheckLastBricks()
    {
        print("check");
       for(int i = 0;i < AllBricks.Count;i++)
        {
            if (AllBricks[i].GetComponent<N_Brick>().Reihe == BricksY.Length-1)
            {
                return;
            }
        }
        SetAllBricksDown();
       SpawnBricks (1);
    }

    void SpawnBricks(int a)
    {
        for ( int j =0; j < a; j++)
        {
            transform.position = new Vector3(StartPosition.x, StartPosition.y- (BrickPrehab.transform.localScale.y +(BrickOffset/4))*j);
            for (int i = 0; i < BricksX; i++)
            {
                //AllBricks.Add(Instantiate(Brick, this.transform.position, this.transform.rotation));
                var togo= Instantiate(BrickPrehab, this.transform.position, this.transform.rotation);
                AllBricks.Add(togo);
                togo.name = "Brick_X " + i + "_Brick_Y" + j;
                togo.GetComponent<N_Brick>().WhatBrick = BricksY[j];
                togo.GetComponent<N_Brick>().ChangeColor();
                if (togo.GetComponent<N_Brick>().WhatBrick == Brick.Normal)
                {
                    BricksWithOutPowerUp.Add(togo);
                }
                transform.position += new Vector3(BrickPrehab.transform.localScale.x + BrickOffset, 0, 0);
                togo.GetComponent<N_Brick>().Reihe=j;
            }
            SetPowerUp();
            BricksWithOutPowerUp.Clear();
        }
    }

    void SetPowerUp()
    {
        if (BricksWithOutPowerUp.Count > 0)
        {
            for (int i = 0; PowerUp > i; i++)
            {
                try
                {
                    int rdm = Random.Range(0, BricksWithOutPowerUp.Count);
                    BricksWithOutPowerUp[rdm].GetComponent<N_Brick>().WhatBrick = Brick.PowerUp;
                    BricksWithOutPowerUp[rdm].GetComponent<N_Brick>().ChangeColor();
                    BricksWithOutPowerUp.RemoveAt(rdm);
                }
                catch { }

            }
        }
    }

    //Setzt all in Trigger bei "true" bei "false" zu Normalen Collidern
    public void SetAllBricksTrigger(bool a)
    {
        for(int i = 0; AllBricks.Count > i; i++)
        {
            AllBricks[i].GetComponent<N_Brick>().SetBrickIntoTrigger(a);
        }
    }
}
