using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerData : ScriptableObject
{
    public int PlayerLives;

    public float respawnPosX;
    public float respawnPosY;
    public float respawnPosZ;


    public float teaCollected;

    public bool canDoubleJump;
    public bool canDash;
    public bool canWallJump;
    public bool canGroundSlam;
    public bool canGrapple;

    public string savedScene;
    public bool hasCheckpoint;

    public bool jumpImg;
    public bool swingImg;
    public bool dashImg;
}
