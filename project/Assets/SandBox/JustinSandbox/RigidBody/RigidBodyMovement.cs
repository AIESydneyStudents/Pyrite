using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyMovement : MonoBehaviour
{

    public float moveSpeed;
    private Rigidbody rb;
    private Vector3 moveInput;
    private Vector3 moveVelocity;
    public float slowFallSpeed;

    public LayerMask groundMask;
   


    private bool canDoubleJump;
    bool isGrounded = false;
    public Transform groundCheck;
    public float groundDistance;

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
        if (!onLeftWallJump && !onRightWallJump)
        {
            if (isGrounded)
            {
                canDoubleJump = true;
                rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            }
            else if(canDoubleJump)
            {
                rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
                canDoubleJump = false;
            }      
        }
        if (onLeftWallJump)
        {
            rb.velocity = new Vector3(rb.velocity.x, wallJumpForce, rb.velocity.z);
        }
        if (onRightWallJump)
        {
            rb.velocity = new Vector3(rb.velocity.x, wallJumpForce, rb.velocity.z);

        }
    }

    private void BouncePad()
    {
        rb.velocity = new Vector3(rb.velocity.x, bouncePadHeight, rb.velocity.z);
    }
    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        

        var dirMove = controls.Player.Move.ReadValue<Vector2>();

        moveInput = new Vector3(dirMove.x * moveSpeed, rb.velocity.y, dirMove.y * moveSpeed);
        moveVelocity = moveInput;


        //if player is on bounce pad call bounce pad function()
        if (onBouncePad)
            BouncePad();
    }

    private void FixedUpdate()
    {
        rb.velocity = moveVelocity;             //add velocity to player
    }
}
