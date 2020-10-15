using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp1 : MonoBehaviour
{
    private PlayerMovement playerMovement;
    public GameObject player;
    void Start()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    public void PowerUp1PickUp()
    {
        playerMovement.canDoubleJump = true;
    }
}
