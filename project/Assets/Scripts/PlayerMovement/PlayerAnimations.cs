using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private PlayerMovement player;
    private Animator anim;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (player.isRunning == true)
    //        anim.Play("Running");
        
    //    if (player.isIdle == true)
    //        anim.Play("Idle");

    //    if (player.isJump == true)
    //        anim.Play("Jump");

    //    if (player.isDoubleJump == true)
    //        anim.Play("Double Jump");

    //    if (player.isGrapple == true)
    //        anim.Play("Grapple");
    //}
}
