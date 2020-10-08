using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnRightWall : MonoBehaviour
{
    public GameObject Player;

    /// <OnRightWallTriggers>
    /// sets OnRightWall bool inside of playerMovement to true and false on triggers
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)       
            Player.GetComponent<PlayerMovement>().onRightWallJump = true;     
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
            Player.GetComponent<PlayerMovement>().onRightWallJump = false;
    }
}
