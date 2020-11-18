using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private PlayerMovement playerMovement;

    [Header("POWER UP BOOLS")]
    public bool canDoubleJump;
    //public bool canGlide;
    public bool canDash;
    public bool canSpin;
    public bool canWallJump;
    public bool canGroundSlam;
    public bool canGrapple;

    public bool jumpImg;
    public bool swingImg;
    public bool dashImg;


    void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    public void PowerUpPickUp()
    {
        AudioManager.instance.Play("PowerUpCollected");
        playerMovement.canDoubleJump = canDoubleJump;
        playerMovement.canDash = canDash;
        playerMovement.canSpin = canSpin;
        playerMovement.canWallJump = canWallJump;
        playerMovement.canGroundSlam = canGroundSlam;
        playerMovement.canGrapple = canGrapple;

        playerMovement.jumpImg = jumpImg;
        playerMovement.swingImg = jumpImg;
        playerMovement.dashImg = jumpImg;




    }
}
