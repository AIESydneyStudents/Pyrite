using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public PlayerData playerData;

    public GameObject jumpImg;
    public GameObject grappleImg;
    public GameObject DashImg;


    private void Start()
    {
        if(playerData.jumpImg)
        {
            jumpImg.SetActive(true);
            grappleImg.SetActive(false);
            DashImg.SetActive(false);
        }
        if (playerData.swingImg)
        {
            jumpImg.SetActive(false);
            grappleImg.SetActive(true);
            DashImg.SetActive(false);
        }
        if (playerData.dashImg)
        {
            jumpImg.SetActive(false);
            grappleImg.SetActive(false);
            DashImg.SetActive(true);
        }
    }

    public void SetDoubleJumpTrue()
    {
        playerData.canDoubleJump = true;
        playerData.canWallJump = true;
        playerData.canDash = false;
        playerData.canGroundSlam = false;
        playerData.canGrapple = false;
        playerData.jumpImg = true;
        playerData.swingImg = false;
        playerData.dashImg = false;
        jumpImg.SetActive(true);
        grappleImg.SetActive(false);
        DashImg.SetActive(false);
    }

    public void SetGrappleTrue()
    {
        playerData.canDoubleJump = false;
        playerData.canWallJump = false;
        playerData.canDash = false;
        playerData.canGroundSlam = false;
        playerData.canGrapple = true;
        playerData.jumpImg = false;
        playerData.swingImg = true;
        playerData.dashImg = false;
        jumpImg.SetActive(false);
        grappleImg.SetActive(true);
        DashImg.SetActive(false);
    }
    public void SetDashTrue()
    {
        playerData.canDoubleJump = false;
        playerData.canWallJump = false;
        playerData.canDash = true;
        playerData.canGroundSlam = true;
        playerData.canGrapple = false;
        playerData.jumpImg = false;
        playerData.swingImg = false;
        playerData.dashImg = true;
        jumpImg.SetActive(false);
        grappleImg.SetActive(false);
        DashImg.SetActive(true);
    }

}
