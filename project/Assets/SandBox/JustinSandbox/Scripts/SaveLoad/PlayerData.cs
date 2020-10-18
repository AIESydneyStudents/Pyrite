using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <DataVariablesToSave>
/// variables that we can use to load and save from a file attach to a empty obj (savemanager)
[System.Serializable]
public class PlayerData
{
    public int PlayerLives;
    public float[] respawnPos;

    public PlayerData(GameMaster gameMaster)
    {
        PlayerLives = gameMaster.playerLives;
        respawnPos = new float[3];
        respawnPos[0] = gameMaster.lastCheckPointPos.x;
        respawnPos[1] = gameMaster.lastCheckPointPos.y;
        respawnPos[2] = gameMaster.lastCheckPointPos.z;
    }
}