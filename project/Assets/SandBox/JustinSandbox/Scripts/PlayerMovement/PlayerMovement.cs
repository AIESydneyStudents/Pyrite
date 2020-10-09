using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //RigidBody and positions for movements
    private Rigidbody rb;
    private Vector3 moveVelocity;

    //Starting values
    private float defaultMoveSpeed;

    //Adjustable player speeds
    [SerializeField] float moveSpeed;
    [SerializeField] float slowFallSpeed;
    [SerializeField] float bouncePadHeight;
    [SerializeField] float onEnemyBounceHeight;
    [SerializeField] float grappleSpeed;
    [SerializeField] float wallJumpForce;
    [SerializeField] float jumpForce;
    [SerializeField] float dashSpeed;
    [SerializeField] float dashCooldown;

    private float dashCurrentCooldown;
    public float dashTime = 0;
    private float currentDashTime;
    private bool isDashing = false;
    private bool StartDashCooldown = false;

    //GroundChecks
    [SerializeField] LayerMask groundMask;
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundDistance;
    private bool isGrounded = false;

    //If Player is interacting with objects change values true. triggered on items collided with
    public bool onLeftWallJump = false;
    public bool onRightWallJump = false;
    public bool OnGrapple = false;

    //Bools to switch which wallJump player can jump of
    private bool canWallJumpLeft = false;
    private bool canWallJumpRight = false;

    //ability to double jump
    private bool canDoubleJump;

    //acess to input system
    private Controls controls;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //get access to input manager
        controls = new Controls();
        //set default movespeed to moveSpeed value given in inspector
        defaultMoveSpeed = moveSpeed;

        currentDashTime = dashTime;

        // call back methods that are called when playerInput is used.
        controls.Player.Jump.performed += Jump_performed;
        controls.Player.SlowFall.performed += SlowFall_performed;
        controls.Player.SlowFallRelease.performed += SlowFallRelease_performed;
        controls.Player.Dash.performed += Dash_performed;

        controls.Enable();
    }

    private void Dash_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (dashCurrentCooldown == dashCooldown)
        {
            isDashing = true;
            StartDashCooldown = true;
        }
    }

    /// < SlowFallInput>
    /// player falling speed is slower while input held down
    private void SlowFall_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (rb != null)
            rb.drag = slowFallSpeed;
    }

    /// <SlowFallReleaseInput>
    /// Players falling speed gets set back to normal
    private void SlowFallRelease_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (rb != null)
            rb.drag = 0f;
    }

    /// <PlayerJump/WallJumpInput>
    /// Player Jumps, if player is in the wallJumpTrigger area PlayerJumps higher up the wall
    private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (rb != null)
        {
            if (isGrounded)
            {
                canWallJumpLeft = true;
                canWallJumpRight = true;
                canDoubleJump = true;
            }
            if (!onLeftWallJump && !onRightWallJump)
            {
                if (isGrounded)
                {
                    Jump(jumpForce);
                }
                else if (canDoubleJump)
                {
                    Jump(jumpForce);
                    canDoubleJump = false;
                }
            }
            if (onLeftWallJump)
            {
                if (canWallJumpLeft)
                {
                    Jump(wallJumpForce);
                    canWallJumpLeft = false;
                    canWallJumpRight = true;
                }
            }
            if (onRightWallJump)
            {
                if (canWallJumpRight)
                {
                    Jump(wallJumpForce);
                    canWallJumpRight = false;
                    canWallJumpLeft = true;
                }
            }
        }
    }

    //gets players moveInput and rotation and stores in moveVelocity
    public void MoveAndRotatePlayer()
    {
        //get the players direction input
        var dirMove = controls.Player.Move.ReadValue<Vector2>();
        //put players input into a vector 3
        moveVelocity = new Vector3(dirMove.x * moveSpeed, rb.velocity.y, dirMove.y * moveSpeed);

        //gets players current direction they are heading
        Vector3 playerDirection = Vector3.right * dirMove.x + Vector3.forward * dirMove.y;
        //if player is moving change its rotation to direction moving
        if (playerDirection.sqrMagnitude > 0.0f)
            transform.rotation = Quaternion.LookRotation(playerDirection);

        if (OnGrapple)
            moveSpeed = grappleSpeed;
        else
            moveSpeed = defaultMoveSpeed;
    }

    ///If dashing is true keep dashing till dash time is less then 0
    ///moves players transform forward
    public void Dash()
    {

        if (isDashing)
        {
            currentDashTime -= Time.deltaTime;
            moveVelocity = transform.forward * dashSpeed;
            if (currentDashTime <= 0)
            {
                isDashing = false;
                currentDashTime = dashTime;
            }
        }
        if (StartDashCooldown)
            dashCurrentCooldown -= Time.deltaTime;

        if (dashCurrentCooldown <= 0)
        {
            dashCurrentCooldown = dashCooldown;
            StartDashCooldown = false;
        }
    }

    public void SetOnLeftWallTrue() => onLeftWallJump = true;       //sets OnLeftWall bool true
    public void SetOnLeftWallFalse() => onLeftWallJump = false;     //sets OnLeftWall bool false
    public void SetOnRightWallTrue() => onRightWallJump = true;     //sets OnRightWall bool true
    public void SetOnRightWallfalse() => onRightWallJump = false;   //sets OnRightWall bool true

    public void OnBouncePad() => Jump(bouncePadHeight); //player bounces if on bounce pad
    public void OnEnemyHead() => Jump(onEnemyBounceHeight); //player bounces if on enemies head
    public void Jump(float jumpHeight) => rb.velocity = new Vector3(rb.velocity.x, jumpHeight, rb.velocity.z);

    void Update()
    {
        //check if player is on ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        //move and rotate player based on input
        MoveAndRotatePlayer();
        //if Dashing
        Dash();
    }

    private void FixedUpdate()
    {
        //add velocity to player
        rb.velocity = moveVelocity;
    }
}
