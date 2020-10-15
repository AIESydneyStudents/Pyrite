using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private PlayerMovement playerMovement;
    public GameObject player;

    [Header("POWER UP BOOLS")]
    public bool canDoubleJump;
    //public bool canGlide;
    public bool canDash;
    public bool canSpin;
    public bool canWallJump;
    public bool canGroundSlam;
    public bool canGrapple;

    void Start()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    public void PowerUpPickUp()
    {        
        playerMovement.canDoubleJump = canDoubleJump;
        playerMovement.canDash = canDash;
        playerMovement.canSpin = canSpin;
        playerMovement.canWallJump = canWallJump;
        playerMovement.canGroundSlam = canGroundSlam;
        playerMovement.canGrapple = canGrapple;
    }
}
