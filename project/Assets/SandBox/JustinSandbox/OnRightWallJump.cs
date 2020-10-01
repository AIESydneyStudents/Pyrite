using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <OnRightWall>
/// Sets a bool to true if player enters TriggerCollider
/// Sets a bool to false if player exits triggerCollider
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
