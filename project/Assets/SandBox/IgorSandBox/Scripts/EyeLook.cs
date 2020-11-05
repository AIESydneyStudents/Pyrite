using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeLook : MonoBehaviour
{
    private Transform player;
    //public Transform defaultLook;
    // Update is called once per frame

    private bool isLooking;

    private Transform startPos;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        startPos = gameObject.transform;
        Debug.Log(startPos.transform);
        //startPos.rotation = Quaternion.Euler(0, 180, 0);
    }
    private void Update()
    {
        if (isLooking == true)
        transform.LookAt(player);
        
        if (isLooking == false)
        {
            //transform.LookAt(startPos);
            // startPos.rotation = Quaternion.Euler(0, 180, 0);
            transform.LookAt(startPos);
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
