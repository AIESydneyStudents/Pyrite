using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFallingPlatformAnim : MonoBehaviour
{
    Animator anim;
    private void Start()
    {
        anim = gameObject.GetComponentInChildren<Animator>();
    }

    public void PlayPlatformShakeAnim()
    {
        anim.Play("ShakingPlatform");
    }
}

