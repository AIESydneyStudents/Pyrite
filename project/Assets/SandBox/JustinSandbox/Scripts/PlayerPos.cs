using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Sets players position to lastCheck point pos
public class PlayerPos : MonoBehaviour
{
    private GameMaster gameMaster;

    void Start()
    {
        gameMaster = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        if (gameMaster.playerLives >= 0)
            transform.position = gameMaster.lastCheckPointPos;

        if (gameMaster.playerLives < 0)
            gameMaster.playerLives = 3;
            
    }


}
