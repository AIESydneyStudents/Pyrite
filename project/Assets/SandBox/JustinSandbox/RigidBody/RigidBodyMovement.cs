using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyMovement : MonoBehaviour
{

    public float moveSpeed;
    private float defaultMoveSpeed;
    private Rigidbody rb;
    private Vector3 moveInput;
    private Vector3 moveVelocity;
    public float slowFallSpeed;

    public LayerMask groundMask;

    public GameObject grappleObj;

    private bool canDoubleJump;
    bool isGrounded = false;
    public Transform groundCheck;
    public float groundDistance;

    [SerializeField] float bouncePadHeight;
    public bool onBouncePad;

    public bool onEnemyBounce;
    [SerializeField] float onEnemyBounceHeight;

    public bool onLeftWallJump = false;
    public bool onRightWallJump = false;

    bool canWallJumpLeft = false;
    bool canWallJumpRight = false;

    public float grappleSpeed;
    public float wallJumpForce;

    public float jumpForce;

    private Controls controls;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //get access to input manager
        controls = new Controls();
        defaultMoveSpeed = moveSpeed;

        // call back methods that are called when playerInput is used.
        controls.Player.Jump.performed += Jump_performed;
        controls.Player.SlowFall.performed += SlowFall_performed;
        controls.Player.SlowFallRelease.performed += SlowFallRelease_performed;
        controls.Enable();
    }

    private void SlowFallRelease_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (rb != null)
            rb.drag = 0f;
    }

    private void SlowFall_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (rb != null)
            rb.drag = slowFallSpeed;
    }

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

    private void BouncePad()
    {
        rb.velocity = new Vector3(rb.velocity.x, bouncePadHeight, rb.velocity.z);
    }

    private void OnEnemyBounce()
    {
        rb.velocity = new Vector3(rb.velocity.x, onEnemyBounceHeight, rb.velocity.z);
    }
    // Update is called once per frame
    void Update()
    {


        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (grappleObj.GetComponent<Grapple>().isSwinging == true)
            moveSpeed = grappleSpeed;
        else
            moveSpeed = defaultMoveSpeed;

        var dirMove = controls.Player.Move.ReadValue<Vector2>();

        moveInput = new Vector3(dirMove.x * moveSpeed, rb.velocity.y, dirMove.y * moveSpeed);

        moveVelocity = moveInput;

        Vector3 playerDirection = Vector3.right * dirMove.x + Vector3.forward * dirMove.y;
        if (playerDirection.sqrMagnitude > 0.0f)
            transform.rotation = Quaternion.LookRotation(playerDirection);

        //if player is on bounce pad call bounce pad function()
        if (onBouncePad)
            BouncePad();

        if (onEnemyBounce)
            OnEnemyBounce();


    }

    private void FixedUpdate()
    {
        rb.velocity = moveVelocity;             //add velocity to player
    }
}
