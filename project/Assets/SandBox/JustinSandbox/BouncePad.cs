using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <BouncePad>
/// Sets a bool to true if player enters TriggerCollider
/// Sets a bool to false if player exits triggerCollider
public class BouncePad : MonoBehaviour
{
    public GameObject Player;    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
            Player.GetComponent<PlayerController>().onBouncePad = true;     
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
            Player.GetComponent<PlayerController>().onBouncePad = false;
    }
}
