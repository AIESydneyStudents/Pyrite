using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMarshmellowAnim : MonoBehaviour
{
    Animator anim;
    private void Start()
    {
       anim = gameObject.GetComponent<Animator>();
    }

    public void PlayMushroomAnim()
    {
        anim.Play("MarshmellowAnim");
    }
}
