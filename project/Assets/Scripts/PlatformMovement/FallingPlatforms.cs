﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatforms : MonoBehaviour
{
    public float fallDelay = 1f;
    public float RespawnDelay = 5f;

    private Rigidbody rb;
    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;
    }

    public void DropPlatforms()
    {
        Invoke("DropPlatform", fallDelay);
        Invoke("RespawnPlatform", fallDelay + RespawnDelay);
    }

    private void DropPlatform()
    {
        rb.isKinematic = false;
    }
    private void RespawnPlatform()
    {
        transform.position = startPos;
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
    }

}
