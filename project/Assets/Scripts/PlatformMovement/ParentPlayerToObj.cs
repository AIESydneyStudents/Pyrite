using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <MoveWithPlatforms>
/// attaches player to the gameObject so that the gameObject moves where the moveing object moves
public class ParentPlayerToObj : MonoBehaviour
{
    private GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void AttachPlayerToObj()
    {
        player.transform.parent = transform;
    }
    public void DetachPlayerFromObj()
    {
        player.transform.parent = null;
    }

}
