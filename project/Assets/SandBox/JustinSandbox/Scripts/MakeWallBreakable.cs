using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeWallBreakable : MonoBehaviour
{
    public Component[] rigidBodies;
    public GameObject player;
    public float breakForce;

    void Start()
    {
        rigidBodies = GetComponentsInChildren<Rigidbody>();
    }
    public void WallBreakable()
    {
        if (player.GetComponent<PlayerMovement>().isDashing == true || player.GetComponent<PlayerMovement>().isGroundSlamming)
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
