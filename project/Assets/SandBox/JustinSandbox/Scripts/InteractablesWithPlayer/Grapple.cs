using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    private LineRenderer lr;

    [SerializeField] Transform ropeStartPoint; // attached to player
    private Transform ropeEndPoint;

    private Vector3 grapplePoint;
    private Vector3 currentGrapplePosition;

    private Controls controls;
    [SerializeField] GameObject player;

    private SpringJoint joint;
    //adjustable joint variable
    [SerializeField] float jointMaxDist = 0.8f;
    [SerializeField] float jointMinDistance = 0.24f;
    [SerializeField] float spring = 4.5f;
    [SerializeField] float damper = 1.27f;
    [SerializeField] float massScale = 10f;

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

    /// <GrappleInputHold>
    /// Call StartGrapple function if GrappleInput is held down 
    private void GrappleButtonDown_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (lr != null)
            StartGrapple();
    }
    /// <GrappleInputRelease>
    /// Call StopGrapple function if GrappleHold input is released
    private void GrappleButtonUp_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (lr != null)
            StopGrapple();
    }

    /// <DrawRope>
    /// If linerender is not null draw the DrawLine for the rope
    void LateUpdate()
    {
        if (lr != null)
            DrawRope();
    }

    /// <StartGrapple()>
    /// Add a joint component on the player and set joint values
    /// attach joint to rope end position
    void StartGrapple()
    {
        if (ropeEndPoint != null)
            if (Physics.Linecast(ropeStartPoint.position, ropeEndPoint.position, out RaycastHit hit))
            {
                player.GetComponent<PlayerMovement>().OnGrapple = true;
                grapplePoint = hit.point;
                joint = player.gameObject.AddComponent<SpringJoint>();
                joint.autoConfigureConnectedAnchor = false;
                joint.connectedAnchor = grapplePoint;

                float distanceFromPoint = Vector3.Distance(ropeStartPoint.position, grapplePoint);

                //The distance grapple will try to keep from grapple point. 
                joint.maxDistance = distanceFromPoint * jointMaxDist;    //0.8f default
                joint.minDistance = distanceFromPoint * jointMinDistance;  //0.24f default

                //Adjustable values of joint to change swinging feel
                joint.spring = spring;    //4.5f default
                joint.damper = damper;      //7f default
                joint.massScale = massScale; //4.5f default

                lr.positionCount = 2;
                currentGrapplePosition = ropeStartPoint.position;
            }
    }

    /// <StopGrapple()>
    /// remove the lineRenderer, destroy the joint , set grappling to false
    void StopGrapple()
    {
        lr.positionCount = 0;
        Destroy(joint);
        player.GetComponent<PlayerMovement>().OnGrapple = false;

    }

    /// <DrawRope()>
    /// draw line renderer between ropeStartPoint and RopeEndPoint
    void DrawRope()
    {
        //If not grappling, don't draw rope
        if (!joint || ropeEndPoint == null)
            return;

        currentGrapplePosition = Vector3.Lerp(currentGrapplePosition, grapplePoint, Time.deltaTime * 8f);

        lr.SetPosition(0, ropeStartPoint.position);
        lr.SetPosition(1, ropeEndPoint.position);
    }

    /// <OnTriggerEnter>
    /// Changes what the Rope end point is if the collider around ropeSwingPoint collides with a grapple object
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Grapple"))
            ropeEndPoint = other.transform;
    }

    /// <OnTriggerExit>
    /// If ropeSwingPoint exits the area where grapple is StopGrapping
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Grapple"))
        {
            ropeEndPoint = null;
            StopGrapple();
        }
    }
}
