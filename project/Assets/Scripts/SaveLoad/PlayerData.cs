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
    public int teaCollected;

    public float playersBodySize;

    public bool canDoubleJump;
    public bool canSlide;
    public bool canGlide;
    public bool canDash;
    public bool canSpin;
    public bool canWallJump;
    public bool canGroundSlam;
    public bool canGrapple;
    public string savedScene;


    public PlayerData(GameMaster gameMaster, TeaTracker teaTracker, PlayerMovement playerMovement)
    {
        PlayerLives = gameMaster.playerLives;
        respawnPos = new float[3];
        respawnPos[0] = gameMaster.lastCheckPointPos.x;
        respawnPos[1] = gameMaster.lastCheckPointPos.y;
        respawnPos[2] = gameMaster.lastCheckPointPos.z;

        playersBodySize = gameMaster.playerBodySize;

        savedScene = gameMaster.savedScene;

        teaCollected = teaTracker.teaCollected;

        canDoubleJump = playerMovement.canDoubleJump;
        canSlide = playerMovement.canSlide;
        canGlide = playerMovement.canGlide;
        canDash = playerMovement.canDash;
        canSpin = playerMovement.canSpin;
        canWallJump = playerMovement.canWallJump;
        canGroundSlam = playerMovement.canGroundSlam;
        canGrapple = playerMovement.canGrapple;


    }
}