using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class P_PowerUps : MonoBehaviour
{
    public PowerUp powerUp;
    [SerializeField] private P_Ball ball;
    
    void Start()
    {
        float rdm = Random.Range(1,100);
        float percentage = rdm / 100;
        Debug.Log(percentage);

        if (percentage <= 0.15f)
        {
            powerUp = PowerUp.lava;
        }
        
        if (percentage >= 0.5f)
        {
            powerUp = PowerUp.split;
        }
        
        if (percentage < 0.5f && percentage > 0.15f)
        {
            powerUp = PowerUp.plus1Live;
        }
        
    }

    public void UsePowerUp()
    {
        switch (powerUp)
        {
            case PowerUp.lava:
                ball.lava();
                break;
            case PowerUp.split:
                ball.split();
                break;
            case PowerUp.plus1Live:
                ball.addLive();
                break;
        }
    }
}

public enum PowerUp
{
    lava,
    split,
    plus1Live
}
