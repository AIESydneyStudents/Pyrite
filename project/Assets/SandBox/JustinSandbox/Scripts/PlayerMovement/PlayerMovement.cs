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

    public void SetOnLeftWallTrue() => onLeftWallJump = true;
    public void SetOnLeftWallFalse() => onLeftWallJump = false;
    public void SetOnRightWallTrue() => onRightWallJump = true;
    public void SetOnRightWallfalse() => onRightWallJump = false;
    public void OnBouncePad() => rb.velocity = new Vector3(rb.velocity.x, bouncePadHeight, rb.velocity.z);
    public void OnEnemyHead()
    {
        rb.velocity = new Vector3(rb.velocity.x, onEnemyBounceHeight, rb.velocity.z);
    }

    void Update()
    {
        //check if player is on ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //get the players direction input
        var dirMove = controls.Player.Move.ReadValue<Vector2>();
        if (!isDashing)
        {
            //put players input into a vector 3
            moveVelocity = new Vector3(dirMove.x * moveSpeed, rb.velocity.y, dirMove.y * moveSpeed);
        }
        //gets players current direction they are heading
        Vector3 playerDirection = Vector3.right * dirMove.x + Vector3.forward * dirMove.y;
        //if player is moving change its rotation to direction moving
        if (playerDirection.sqrMagnitude > 0.0f)
            transform.rotation = Quaternion.LookRotation(playerDirection);

        if (OnGrapple)
            moveSpeed = grappleSpeed;
        else
            moveSpeed = defaultMoveSpeed;

        ///If dashing is true keep dashing till dash time is less then 0
        ///moves players transform forward
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

    private void FixedUpdate()
    {
        //add velocity to player
        rb.velocity = moveVelocity;
    }
}
