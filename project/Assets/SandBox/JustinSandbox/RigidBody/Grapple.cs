using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    private LineRenderer lr;
    public Transform ropeStartPoint;
    private Transform ropeEndPoint;
    public GameObject player;
    private SpringJoint joint;
    private Vector3 grapplePoint;
    private Controls controls;
    public float jointMaxDist;
    public float jointMinDistance;
    public float spring;
    public float damper;
    public float massScale;

    public bool isSwinging;
    

    void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }
    private void Start()
    {
        controls = new Controls();
        controls.Player.GrappleButtonDown.performed += GrappleButtonDown_performed;
        controls.Player.GrappleButtonUp.performed += GrappleButtonUp_performed;

        controls.Enable();
    }

    private void GrappleButtonUp_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        StopGrapple();
    }

    private void GrappleButtonDown_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        StartGrapple();
    }
    void LateUpdate()
    {
        DrawRope();
    }


    void StartGrapple()
    {
        RaycastHit hit;
        if (ropeEndPoint != null)
            if (Physics.Linecast(ropeStartPoint.position, ropeEndPoint.position, out hit))
            {
                isSwinging = true;
                grapplePoint = hit.point;
                joint = player.gameObject.AddComponent<SpringJoint>();
                joint.autoConfigureConnectedAnchor = false;
                joint.connectedAnchor = grapplePoint;

                float distanceFromPoint = Vector3.Distance(ropeStartPoint.position, grapplePoint);

                //The distance grapple will try to keep from grapple point. 
                joint.maxDistance = distanceFromPoint * jointMaxDist;    //0.8f default
                joint.minDistance = distanceFromPoint * jointMinDistance;  //0.24f default

                //Adjust these values to fit your game.
                joint.spring = spring;    //4.5f default
                joint.damper = damper;      //7f default
                joint.massScale = massScale; //4.5f default

                lr.positionCount = 2;
                currentGrapplePosition = ropeStartPoint.position;
            }
    }


    /// <summary>
    /// Call whenever we want to stop a grapple
    /// </summary>
    void StopGrapple()
    {
        lr.positionCount = 0;
        Destroy(joint);
        isSwinging = false;

    }

    private Vector3 currentGrapplePosition;

    void DrawRope()
    {
        //If not grappling, don't draw rope
        if (!joint || ropeEndPoint == null) return;

        currentGrapplePosition = Vector3.Lerp(currentGrapplePosition, grapplePoint, Time.deltaTime * 8f);

        lr.SetPosition(0, ropeStartPoint.position);
        lr.SetPosition(1, ropeEndPoint.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Grapple")
        {
            ropeEndPoint = other.transform;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Grapple")
        {
            ropeEndPoint = null;
            StopGrapple();
        }
    }
}
