using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RbOnRightWall : MonoBehaviour
{
    public GameObject Player;

    private void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            Player.GetComponent<RigidBodyMovement>().onRightWallJump = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
            Player.GetComponent<RigidBodyMovement>().onRightWallJump = false;
    }
}
