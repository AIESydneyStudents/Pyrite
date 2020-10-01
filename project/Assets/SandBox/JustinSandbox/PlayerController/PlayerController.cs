using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;

    [SerializeField] float moveSpeed;
    private Vector3 velocity;
    [SerializeField] float gravity;
    private float initialGravity;
    [SerializeField] float slowFallGravity;

    public bool onBouncePad = false;

    [SerializeField] float bouncePadHeight;
    [SerializeField] float jumpHeight;
    [SerializeField] int jumpCount;
    private int jumpCounter;
    private bool isJumping;
    private bool canJump;

    [SerializeField] float slopeForce;
    [SerializeField] float slopeForceRayLength;


    public bool onLeftWallJump = false;
    public bool onRightWallJump = false;

    [SerializeField] float wallJumpForce;

    private LineRenderer lr;
    public Transform ropeStartPoint;
    public Transform ropeEndPoint;
    bool drawRope = false;
    bool OnSwing = false;
    public GameObject player;

    private Controls controls;

    /// <Start()>
    /// Activate InputSystem, get acess the CharacterController, sets initial values of variables
    private void Start()
    {
        //get access to input manager
        controls = new Controls();

        // call back methods that are called when playerInput is used.
        controls.Player.Jump.performed += Jump_performed;
        controls.Player.SlowFall.performed += SlowFall_performed;
        controls.Player.SlowFallRelease.performed += SlowFallRelease_performed;
        controls.Player.GrappleButtonDown.performed += GrappleButtonDown_performed;
        controls.Player.GrappleButtonUp.performed += GrappleButtonUp_performed;
        //enable controls
        controls.Enable();

        //get access to characterController Componment
        controller = GetComponent<CharacterController>();

        lr = GetComponent<LineRenderer>();

        //set value of initial gravity to value of gravity set in inspector
        initialGravity = gravity;
    }

    /// <SlowFallReleased>
    /// if Jump input is held down and then released set gravity back to initial gravity.
    private void SlowFallRelease_performed(InputAction.CallbackContext obj)
    {
        gravity = initialGravity;
    }

    /// <SlowFall()>
    /// If jump input is held down set gravity to slowfall gravaity
    private void SlowFall_performed(InputAction.CallbackContext obj)
    {
        gravity = slowFallGravity;
    }

    private void GrappleButtonDown_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        drawRope = true;
        lr.positionCount = 2;
        OnSwing = true;
    }

    private void GrappleButtonUp_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        drawRope = false;
        lr.positionCount = 0;
        OnSwing = false;
    }



    /// <OnSlopeBool()>
    /// Puts a raycast under the player to check if the ground below is a sloped surface
    private bool OnSlope()
    {
        if (isJumping)
            return false;

        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, controller.height / 2 * slopeForceRayLength))
            if (hit.normal != Vector3.up)
                return true;
        return false;
    }

    /// <Jump>
    /// When Jump input has been triggered
    private void Jump_performed(InputAction.CallbackContext obj)
    {
        //if canJump == true add velocity upwards, -1 from jump counter and set isJumping to true
        if (canJump)
        {
            jumpCounter -= 1;
            isJumping = true;
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        //if onLeftWallJump trigger jumpCounter + 1, push player to right with
        //velocity.x and then add some height in the velocity.y
        if (onLeftWallJump)
        {
            if (jumpCounter <= 1)
                jumpCounter += 1;

            velocity.x = wallJumpForce;
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        //if onRightWallJump trigger jumpCounter + 1, push player to right with
        //velocity.x and then add some height in the velocity.y
        if (onRightWallJump)
        {
            if (jumpCounter <= 1)
                jumpCounter += 1;

            velocity.x = -wallJumpForce;
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    /// <BouncePad()>
    /// Bounce player upwards on bounce pad
    private void BouncePad()
    {
        velocity.y = Mathf.Sqrt(bouncePadHeight * -2f * gravity);
    }

    private void OnRope()
    {
        gravity = 2;
    }

    /// <Update()>
    /// Player Movement logic
    private void Update()
    {
        //if jump counter is above 0 allow player to jump else cant jump
        if (jumpCounter > 0)
            canJump = true;
        else
            canJump = false;

        //if player is on bounce pad call bounce pad function()
        if (onBouncePad)
            BouncePad();

        if (OnSwing)
        {
            gravity = 8f;
        }
        //if the player is on the ground and players y velocity is less then 0 
        else if (controller.isGrounded && velocity.y < 0)
        {
            //set values back to initial values
            velocity.y = -2f;           //-2 instead of 0 to force the player on the ground a bit more             
            velocity.x = 0;
            isJumping = false;
            gravity = initialGravity;
        }
        else gravity = initialGravity;

        //read values from inputSystem to get players input
        var dirMove = controls.Player.Move.ReadValue<Vector2>();

        //gets the direction the player is facing based on x y z movement
        Vector3 move =
            transform.right * dirMove.x * moveSpeed +
            transform.forward * dirMove.y * moveSpeed +
            transform.up * velocity.y;

        //Move the player if player is not on the wall jump trigger
        if (!onLeftWallJump || !onRightWallJump)
            controller.Move(move * Time.deltaTime);
        //if player is on slope force the player down to stop jittering going down slopes
        if ((dirMove.x != 0 || dirMove.y != 0) && OnSlope())
            controller.Move(Vector3.down * controller.height / 2 * slopeForce * Time.deltaTime);


        //falling physics velocity.y increased every second
        velocity.y += gravity * Time.deltaTime;
        //apply falling gravity to character controller
        controller.Move(velocity * Time.deltaTime);

    }

    /// <LateUpdate()>
    /// Sets JumpCounter back to jumpCount on grounded
    private void LateUpdate()
    {
        //if player is grounded set jumpcounter back to initial jumpCount done in LateUpdate()
        //to prevent player still being grounded in same frame player jumped to ensure a jump is always 
        //calculated and reset at correct time.
        if (controller.isGrounded)
            jumpCounter = jumpCount;

        if (drawRope == true)
            DrawRope();
    }

    private void DrawRope()
    {
        lr.SetPosition(0, ropeStartPoint.position);
        lr.SetPosition(1, ropeEndPoint.position);
    }


}
