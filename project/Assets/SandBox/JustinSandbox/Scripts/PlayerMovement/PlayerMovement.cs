using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //RigidBody and positions for movements
    private Rigidbody rb;
    private Vector3 moveInput;
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
    
    //GroundChecks
    [SerializeField] LayerMask groundMask;
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundDistance;
    private bool isGrounded = false;

    [SerializeField] GameObject grappleObj;

    //If Player is interacting with objects change values true. triggered on items collided with
    public bool onBouncePad = false;
    public bool onEnemyBounce = false;
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

        // call back methods that are called when playerInput is used.
        controls.Player.Jump.performed += Jump_performed;
        controls.Player.SlowFall.performed += SlowFall_performed;
        controls.Player.SlowFallRelease.performed += SlowFallRelease_performed;
        controls.Enable();
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
            }
            if (!onLeftWallJump && !onRightWallJump)
            {
                if (isGrounded)
                {
                    canDoubleJump = true;
                    rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
                }
                else if (canDoubleJump)
                {
                    rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
                    canDoubleJump = false;
                }
            }
            if (onLeftWallJump)
            {
                if (canWallJumpLeft)
                {
                    rb.velocity = new Vector3(rb.velocity.x, wallJumpForce, rb.velocity.z);
                    canWallJumpLeft = false;
                    canWallJumpRight = true;
                }
            }
            if (onRightWallJump)
            {
                if (canWallJumpRight)
                {
                    rb.velocity = new Vector3(rb.velocity.x, wallJumpForce, rb.velocity.z);
                    canWallJumpRight = false;
                    canWallJumpLeft = true;
                }
            }
        }
    }

    void Update()
    {
        //check if player is on ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //get the players direction input
        var dirMove = controls.Player.Move.ReadValue<Vector2>();
        //put players input into a vector 3
        moveInput = new Vector3(dirMove.x * moveSpeed, rb.velocity.y, dirMove.y * moveSpeed);
        //set the moveVelocity to = the moveInput
        moveVelocity = moveInput;

        //gets players current direction they are heading
        Vector3 playerDirection = Vector3.right * dirMove.x + Vector3.forward * dirMove.y;
        //if player is moving change its rotation to direction moving
        if (playerDirection.sqrMagnitude > 0.0f)
            transform.rotation = Quaternion.LookRotation(playerDirection);

        //If player is interecting with following objects change players moveing behaviours
        if (onBouncePad)
            rb.velocity = new Vector3(rb.velocity.x, bouncePadHeight, rb.velocity.z);

        if (onEnemyBounce)
            rb.velocity = new Vector3(rb.velocity.x, onEnemyBounceHeight, rb.velocity.z);

        if (OnGrapple)
            moveSpeed = grappleSpeed;
        else
            moveSpeed = defaultMoveSpeed;

    }

    private void FixedUpdate()
    {
        //add velocity to player
        rb.velocity = moveVelocity;            
    }
}
