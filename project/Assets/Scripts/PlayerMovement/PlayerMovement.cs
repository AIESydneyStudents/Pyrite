﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Controls Controls
    {
        get { return ControlsManager.instance; }
    }

    private Animator anim;
    private HitEffect[] hitEffect;

    PauseMenu pauseMenu;

    //RigidBody and positions for movements
    private Rigidbody rb;
    private Vector3 moveVelocity;
    //Starting values
    private float defaultMoveSpeed;
    private Vector3 initalGravity;
    private TrailRenderer trail;

    public Transform defaultStartPos;


    [Header("Gravity")]
    [SerializeField] float initialGravityValue = -30f;


    [Header("PLAYER MOVE SPEEDS")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float jumpForce = 15f;

    [Header("ON TRIGGER VARIABLES")]
    [SerializeField] float onEnemyBounceHeight = 15f;
    [SerializeField] float bouncePadHeight = 30f;
    [SerializeField] float OnFloatPadSpeed = 15f;
    [SerializeField] float wallJumpForce = 30f;

    [Header("DASH VARIABLES")]
    [SerializeField] float dashSpeed = 100f;
    [SerializeField] float dashCooldown = 3f;
    [SerializeField] float dashTime = 0.1f;
    private float dashCurrentCooldown;
    private float currentDashTime;
    private bool StartDashCooldown = false;
    [HideInInspector]
    public bool isDashing = false;

    [Header("GROUND SLAM VARIABLES")]
    [SerializeField] float groundSlamGravityValue = -200f;
    private Vector3 groundSlamGravity;
    [HideInInspector]
    public bool isGroundSlamming = false;

    //GroundChecks
    [Header("GROUND CHECKS")]
    [SerializeField] LayerMask groundMask = 0;
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundDistance = 0.4f;
    [SerializeField] bool isGrounded = false;

    [Header("GRAPPLES VARIABLES")]
    [SerializeField] float grappleSpeed = 15f;
    [HideInInspector]
    public bool OnGrapple = false;


    //If Player is interacting with objects change values true. triggered on items collided with
    private bool onLeftWallJump = false;
    private bool onRightWallJump = false;
    //Bools to switch which wallJump player can jump of
    private bool canWallJumpLeft = false;
    private bool canWallJumpRight = false;

    private bool doubleJumpActive;

    bool playerAirBound = false;

    public PlayerData playerData;

    void Start()
    {
        anim = gameObject.GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
        trail = GetComponent<TrailRenderer>();
        hitEffect = GetComponentsInChildren<HitEffect>();

        pauseMenu = FindObjectOfType<PauseMenu>();

        initalGravity = new Vector3(0, initialGravityValue, 0);
        groundSlamGravity = new Vector3(0, groundSlamGravityValue, 0);

        //set default movespeed to moveSpeed value given in inspector
        defaultMoveSpeed = moveSpeed;

        currentDashTime = dashTime;

        // call back methods that are called when playerInput is used.
        Controls.Player.Jump.performed += Jump_performed;
        Controls.Player.Dash.performed += Dash_performed;
        Controls.Player.GroundSmash.performed += GroundSmash_performed;

        Controls.Enable();

        Physics.gravity = initalGravity;

        if (playerData.hasCheckpoint)
        {
            transform.position = new Vector3(playerData.respawnPosX, playerData.respawnPosY, playerData.respawnPosZ);
        }
        else
            transform.position = defaultStartPos.position;

    }

    private void GroundSmash_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (playerData.canGroundSlam == false)
            return;
        trail.emitting = true;
        Physics.gravity = groundSlamGravity;
        AudioManager.instance.Play("DashSlamWhoosh");

        isGroundSlamming = true;
    }

    private void Dash_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (!playerData.canDash)
            return;
        if (dashCurrentCooldown == dashCooldown)
        {
            trail.emitting = true;
            isDashing = true;
            StartDashCooldown = true;
        }
    }


    /// <PlayerJump/WallJumpInput>
    /// Player Jumps, if player is in the wallJumpTrigger area PlayerJumps higher up the wall
    private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (rb != null)
        {
            if (isGrounded && playerData.canWallJump)
            {
                canWallJumpLeft = true;
                canWallJumpRight = true;
            }

            if (isGrounded && playerData.canWallJump)
            {
                doubleJumpActive = true;
            }

            if (!onLeftWallJump && !onRightWallJump)
            {
                if (isGrounded)
                {
                    AudioManager.instance.Play("Jump");
                    Jump(jumpForce);
                    anim.Play("Jump");
                    anim.SetBool("isIdle", false);
                    anim.SetBool("isRunning", false);

                }
                else if (doubleJumpActive && playerData.canDoubleJump)
                {
                    AudioManager.instance.Play("Jump");
                    Jump(jumpForce);
                    doubleJumpActive = false;

                    anim.Play("Double Jump");
                }
            }
            if (onLeftWallJump && playerData.canWallJump)
            {
                if (canWallJumpLeft)
                {
                    AudioManager.instance.Play("Jump");
                    Jump(wallJumpForce);
                    canWallJumpLeft = false;
                    canWallJumpRight = true;
                }
            }
            if (onRightWallJump && playerData.canWallJump)
            {
                if (canWallJumpRight)
                {
                    AudioManager.instance.Play("Jump");
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
        if (pauseMenu.gameIsPaused == true)
            return;

        //get the players direction input
        var dirMove = Controls.Player.Move.ReadValue<Vector2>();

        if (isGrounded == true)
        {
            if (dirMove.x != 0 || dirMove.y != 0)
            {
                if (AudioManager.instance.IsPlaying("Walking") == false)
                    AudioManager.instance.Play("Walking");


                anim.SetBool("isRunning", true);
                anim.SetBool("isIdle", false);
                anim.SetBool("isGrapple", false);
            }
            else
            {
                AudioManager.instance.Stop("Walking");
                anim.SetBool("isIdle", true);
                anim.SetBool("isRunning", false);
                anim.SetBool("isGrapple", false);
            }
        }


        //put players input into a vector 3
        moveVelocity = new Vector3(dirMove.x * moveSpeed, rb.velocity.y, dirMove.y * moveSpeed);

        //gets players current direction they are heading
        Vector3 playerDirection = Vector3.right * dirMove.x + Vector3.forward * dirMove.y;
        //if player is moving change its rotation to direction moving
        if (playerDirection.sqrMagnitude > 0.0f)
            transform.rotation = Quaternion.LookRotation(playerDirection);

        if (OnGrapple && playerData.canGrapple)
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
            AudioManager.instance.Play("DashSlamWhoosh");
            currentDashTime -= Time.deltaTime;
            moveVelocity = transform.forward * dashSpeed;
            if (currentDashTime <= 0)
            {
                trail.emitting = false;
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



    public void OnBouncePad()
    {
        AudioManager.instance.Play("MarshmellowPad");
        Jump(bouncePadHeight); //player bounces if on bounce pad
        Physics.gravity = initalGravity;
        anim.Play("Double Jump");
        canWallJumpLeft = true;
        canWallJumpRight = true;
    }

    public void OnFloatPad()
    {
        Jump(OnFloatPadSpeed);
        anim.Play("Jump");
    }
    public void OnEnemyHead()
    {
        if (isDashing == true)
            return;

        Jump(onEnemyBounceHeight); //player bounces if on enemies head
        foreach (HitEffect hit in hitEffect)
        {
            hit.HitEffectPlay();
        }
        AudioManager.instance.Play("JumpOnEnemyHead");
        AudioManager.instance.Play("CoffeeBeanDeath");
        anim.Play("Double Jump");
    }
    public void Jump(float jumpHeight)
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpHeight, rb.velocity.z);
    }

    void Update()
    {
        //check if player is on ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (onLeftWallJump == true)
        {
            if (!isGrounded)
                anim.Play("Right_Grab");
        }
        else if (onRightWallJump == true)
        {
            if (!isGrounded)
                anim.Play("Left_Grab");
        }

        else if (!isGroundSlamming)
            Physics.gravity = initalGravity;



        if (isGrounded == false)
        {
            anim.SetBool("isRunning", false);
            AudioManager.instance.Stop("Walking");
            playerAirBound = true;
        }

        if (isGrounded && playerAirBound == true)
        {
            AudioManager.instance.Play("PlayerFallImpact");
            playerAirBound = false;
        }

        if (isGroundSlamming)
        {
            if (isGrounded)
            {
                Physics.gravity = initalGravity;
                trail.emitting = false;
            }
            if (moveVelocity.y == 0)
                isGroundSlamming = false;
        }
        //move and rotate player based on input
        MoveAndRotatePlayer();
        //if Dashing
        Dash();


        if (OnGrapple)
        {
            anim.SetBool("isGrapple", true);
            anim.SetBool("isRunning", false);
            anim.SetBool("isIdle", false);
        }
        else
        {
            anim.SetBool("isGrapple", false);
            if (isGrounded == false)
                anim.SetBool("isIdle", true);
        }
    }

    private void OnDestroy()
    {
        Controls.Player.Jump.performed -= Jump_performed;
        Controls.Player.Dash.performed -= Dash_performed;
        Controls.Player.GroundSmash.performed -= GroundSmash_performed;
    }
    private void FixedUpdate()
    {
        //add velocity to player
        rb.velocity = moveVelocity;
    }

    public void DisableControls()
    {
        Controls.Disable();
    }
}
