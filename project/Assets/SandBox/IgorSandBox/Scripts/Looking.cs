using System;
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
    private bool isLooking;
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
        if (isLooking == true)
        {
            lookDir = (playerPos.position - eyePos.position);
            lookDir.Normalize();

            lookDir.z = 0f;
            lookDir.Normalize();

            float frontOfEye = pupilPos.transform.position.z;// + startPupilPosition.z + eyeFront;
            var tmpPupilPos = pupilPos.transform.position;
            tmpPupilPos = eyePos.position + (lookDir * eyeRadius);
            tmpPupilPos.z = frontOfEye;

            pupilPos.transform.position = tmpPupilPos;
            Debug.Log(isLooking);
        }

        if (isLooking == false)
        {
            pupilPos.transform.localPosition = startPupilPosition;
            Debug.Log(isLooking);

        }


    }

    public void LookAtMeTrue()
    {
        isLooking = true;
    }
    public void LookAtMeFalse()
    {
        isLooking = false;
    }

}
