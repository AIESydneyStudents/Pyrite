using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeSwing : MonoBehaviour
{
    //private LineRenderer lr;
    //public Transform ropeStartPoint;
    //public Transform ropeEndPoint;
    //bool drawRope = false;
    //public GameObject player;


    //private Controls controls;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    controls = new Controls();
    //    controls.Player.GrappleButtonDown.performed += GrappleButtonDown_performed;
    //    controls.Player.GrappleButtonUp.performed += GrappleButtonUp_performed;
    //    controls.Enable();
    //    lr = GetComponent<LineRenderer>();
    //}

    //private void GrappleButtonDown_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    //{
    //    drawRope = true;
    //    lr.positionCount = 2;
    //    player.GetComponent<PlayerController>().onRope = true;
    //}

    //private void GrappleButtonUp_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    //{
    //    drawRope = false;
    //    lr.positionCount = 0;
    //    player.GetComponent<PlayerController>().onRope = true;
    //    player.GetComponent<PlayerController>().SetGravity(-31.04f);
    //}


    //private void LateUpdate()
    //{
    //    if (drawRope == true)
    //    DrawRope();
    //}
    //private void DrawRope()
    //{
    //    lr.SetPosition(0, ropeStartPoint.position);
    //    lr.SetPosition(1, ropeEndPoint.position);
    //}
}
