﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapTrailEffect : MonoBehaviour
{
    private TrailRenderer trail;


    public PlayerMovement playMov;
    // Start is called before the first frame update
    void Start()
    {
        trail = GetComponent<TrailRenderer>();


    }

    // Update is called once per frame
    void Update()
    {
        if (playMov.OnGrapple)
            trail.emitting = true;

        else
            trail.emitting = false;

    }
}