﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Sets players position to lastCheck point pos
public class PlayerPos : MonoBehaviour
{
    private GameMaster gameMaster;
    public Transform startpos;

    void Start()
    {
        gameMaster = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        if (gameMaster.playerLives >= 0)
        {
            transform.position = gameMaster.lastCheckPointPos;
        }

        if (gameMaster.playerLives < 0)
        {
            gameMaster.lastCheckPointPos = startpos.position;    
            gameMaster.playerLives = 3;
        }
            
    }


}
