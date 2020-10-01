using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <MoveWithPlatforms>
/// attaches player to the gameObject so that the gameObject moves where the moveing object moves
public class MoveWithPlatform : MonoBehaviour
{

    public GameObject Player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
            Player.transform.parent = transform;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
            Player.transform.parent = null;
    }
}
