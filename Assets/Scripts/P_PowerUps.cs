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
        int rdm = Random.Range(1,3);

        switch (rdm)
        {
            case 1:
                powerUp = PowerUp.lava;
                break;
            case 2:
                powerUp = PowerUp.split;
                break;
            case 3:
                powerUp = PowerUp.plus1Live;
                break;
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
    plus1Live,
}
