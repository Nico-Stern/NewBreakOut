using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_LiveManager : MonoBehaviour
{
    public int lives;
    public int currenLives;
    void Start()
    {
        lives = 3;
        currenLives = lives;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
