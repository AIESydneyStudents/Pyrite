using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnemyBounce : MonoBehaviour
{
    public GameObject Player;

    /// <BounceOnEnemies>
    /// sets onEnemyBounce bool inside of playerMovement to true and false on triggers
    /// Destroy enemy on trigger exit
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
            Player.GetComponent<PlayerMovement>().onEnemyBounce = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
        {
            Player.GetComponent<PlayerMovement>().onEnemyBounce = false;
            Destroy(this.gameObject);
        }
    }
}
