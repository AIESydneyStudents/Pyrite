﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Looking : MonoBehaviour
{

    public Transform eyePos;
    public Transform playerPos;
    public GameObject pupilPos;
    public float eyeRadius = 3.0f;
    public float eyeFront = 1.0f;
    Vector3 startPupilPosition;

    Vector3 lookDir;

    // Start is called before the first frame update
    void Start()
    {
        startPupilPosition = pupilPos.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        lookDir = (playerPos.position - eyePos.position);
        lookDir.Normalize();

        lookDir.z = 0f;
        lookDir.Normalize();

        float frontOfEye = pupilPos.transform.position.z;
        var tmpPupilPos = pupilPos.transform.position;
        tmpPupilPos = eyePos.position + (lookDir * eyeRadius);
        tmpPupilPos.z = eyeFront;

        pupilPos.transform.position = tmpPupilPos;

        if ((transform.position - playerPos.transform.position).magnitude < 10)
        {
            // look at yes
        }
        else
        {
            // look at no
        }
    }

    
}
