using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnemyBounce : MonoBehaviour
{
    public GameObject Player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
            Player.GetComponent<RigidBodyMovement>().onEnemyBounce = true;

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
        {
            Player.GetComponent<RigidBodyMovement>().onEnemyBounce = false;
            Destroy(this.gameObject);
        }
    }
}
