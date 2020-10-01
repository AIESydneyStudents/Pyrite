using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <OnLeftWall>
/// Sets a bool to true if player enters TriggerCollider
/// Sets a bool to false if player exits triggerCollider
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
