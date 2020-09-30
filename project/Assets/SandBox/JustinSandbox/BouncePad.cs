using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
