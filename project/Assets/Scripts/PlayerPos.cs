using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Sets players position to lastCheck point pos
public class PlayerPos : MonoBehaviour
{
    private GameMaster gameMaster;
    public Transform startpos;
    public TeaTracker teaTracker;

    private void Awake()
    {
        gameMaster = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        teaTracker = GameObject.FindGameObjectWithTag("GameManager").GetComponent<TeaTracker>();
        if (gameMaster.playerLives < 0)
        {
            gameMaster.lastCheckPointPos = startpos.position;
            transform.position = gameMaster.lastCheckPointPos;
            gameMaster.playerLives = 3;
            teaTracker.teaCollected = 0;
        }
    }

    void Start()
    {

        if (!SaveLoad.SaveExists("PlayerData"))
        {
            gameMaster.lastCheckPointPos = startpos.position;
            transform.position = gameMaster.lastCheckPointPos;
        }

        else if (gameMaster.playerLives >= 0)
        {
            transform.position = gameMaster.lastCheckPointPos;
        }



    }


}
