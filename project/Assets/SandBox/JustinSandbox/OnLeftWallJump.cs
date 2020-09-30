using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLeftWallJump : MonoBehaviour
{
    public GameObject Player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
            Player.GetComponent<PlayerController>().onLeftWallJump = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
            Player.GetComponent<PlayerController>().onLeftWallJump = false;
    }
}
