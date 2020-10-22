using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeWallBreakable : MonoBehaviour
{
    public Component[] rigidBodies;
    //public GameObject player;
    public float breakForce;

    private PlayerMovement playerMovement;

    void Start()
    {
        rigidBodies = GetComponentsInChildren<Rigidbody>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }
    public void WallBreakable()
    {
        if (playerMovement.isDashing == true || playerMovement.isGroundSlamming)
        {
            foreach (Rigidbody rb in rigidBodies)
            {
                rb.isKinematic = false;
                Vector3 force = (rb.transform.position - transform.position).normalized * breakForce;
                rb.AddForce(force);
                Destroy(gameObject, 4);
            } 
        }
    }
}
