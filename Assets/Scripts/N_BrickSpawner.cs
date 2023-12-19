using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N_BrickSpawner : MonoBehaviour
{
    [SerializeField] bool BricksEqaulsOnX;
    [SerializeField] bool BricksEqaulsOnY;
    [SerializeField] int BricksX;
    [SerializeField] Brick[] BricksY;
    [SerializeField] float BrickOffset;
    [SerializeField] GameObject BrickPrehab;
    Vector3 StartPosition;
    [SerializeField] List<GameObject> AllBricks;
    [SerializeField] List<GameObject> BricksWithOutPowerUp;
    [SerializeField] int PowerUp;

    void Start()
    {
        StartPosition = new Vector3(0, 4.5f+BrickOffset, 0);
        if (BricksX%2==0)
        {
            StartPosition.x += ((BrickPrehab.transform.localScale.x + BrickOffset) / 2);
        }
        StartPosition.x -= (BricksX / 2) * (BrickPrehab.transform.localScale.x + BrickOffset);
        this.transform.position = StartPosition;
        SpawnBricks();
        
    }

    void SpawnBricks()
    {
        for ( int j =0; j < BricksY.Length; j++)
        {
            transform.position = new Vector3(StartPosition.x, StartPosition.y- (BrickPrehab.transform.localScale.y + BrickOffset)*j);
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
                int rdm = Random.Range(0, BricksWithOutPowerUp.Count);
                BricksWithOutPowerUp[rdm].GetComponent<N_Brick>().WhatBrick = Brick.PowerUp;
                BricksWithOutPowerUp[rdm].GetComponent<N_Brick>().ChangeColor();
                BricksWithOutPowerUp.RemoveAt(rdm);
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
