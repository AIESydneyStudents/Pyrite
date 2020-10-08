using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour
{
    public GameObject Player;

    /// <BouncePadTriggers>
    /// sets OnBouncePad bool inside of playerMovement to true and false on triggers
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
            Player.GetComponent<PlayerMovement>().onBouncePad = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
            Player.GetComponent<PlayerMovement>().onBouncePad = false;
    }
}

