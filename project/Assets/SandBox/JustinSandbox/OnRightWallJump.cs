using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnRightWallJump : MonoBehaviour
{
    public GameObject Player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
            Player.GetComponent<PlayerController>().onRightWallJump = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
            Player.GetComponent<PlayerController>().onRightWallJump = false;
    }
}
