using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyMovement : MonoBehaviour
{

    public float moveSpeed;
    private Rigidbody rb;
    private Vector3 moveInput;
    private Vector3 moveVelocity;
    public float gravity;
    public float slowFallSpeed;


    [SerializeField] int jumpCount;
    private int jumpCounter;
    private bool canJump;
    bool isGrounded = false;
    [SerializeField] float bouncePadHeight;
    public bool onBouncePad;

    public bool onLeftWallJump = false;
    public bool onRightWallJump = false;

    public float wallJumpForce;



    public float jumpForce;

    private Controls controls;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        //get access to input manager
        controls = new Controls();

        // call back methods that are called when playerInput is used.
        controls.Player.Jump.performed += Jump_performed;
        controls.Player.SlowFall.performed += SlowFall_performed;
        controls.Player.SlowFallRelease.performed += SlowFallRelease_performed;
        //enable controls
        controls.Enable();
    }

    private void SlowFallRelease_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        rb.drag = 0f;
    }

    private void SlowFall_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        rb.drag = slowFallSpeed;
    }

    private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (!onLeftWallJump && !onRightWallJump && canJump)
        {
            jumpCounter -= 1;
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
        if (onLeftWallJump)
        {
            if (jumpCounter <= 1)
                jumpCounter += 1;
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
        if (onRightWallJump)
        {
            if (jumpCounter <= 1)
                jumpCounter += 1;
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);

        }
    }

    private void BouncePad()
    {
        rb.velocity = new Vector3(rb.velocity.x, bouncePadHeight, rb.velocity.z);
    }
    // Update is called once per frame
    void Update()
    {
        var dirMove = controls.Player.Move.ReadValue<Vector2>();

        moveInput = new Vector3(dirMove.x * moveSpeed, rb.velocity.y, dirMove.y * moveSpeed);
        moveVelocity = moveInput;

        //if jump counter is above 0 allow player to jump else cant jump
        if (jumpCounter > 0)
            canJump = true;
        else
            canJump = false;

        //if player is on bounce pad call bounce pad function()
        if (onBouncePad)
            BouncePad();
    }

    private void FixedUpdate()
    {
        //Move the player if player is not on the wall jump trigger
        rb.velocity = moveVelocity;             //add velocity to player
        

    }
    private void OnTriggerEnter(Collider other)
    {
        isGrounded = true;
    }
    private void OnTriggerExit(Collider other)
    {
        isGrounded = false;
    }

    private void LateUpdate()
    {
        if (isGrounded == true)
        {
            jumpCounter = jumpCount;
        }
    }
}
