using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLeftWall : MonoBehaviour
{
    public GameObject Player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
            Player.GetComponent<PlayerMovement>().onLeftWallJump = true;    
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
            Player.GetComponent<PlayerMovement>().onLeftWallJump = false;
    }
}
