using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;

    [SerializeField] float moveSpeed = 12f;
    private Vector3 velocity;
    [SerializeField] float gravity = -9.81f;

    public bool onBouncePad = false;

    [SerializeField] float bouncePadHeight;
    [SerializeField] float jumpHeight = 3.0f;
    public int jumpCount = 2;
    private int jumpCounter;
    private bool isJumping;
    private bool canJump;

    [SerializeField] float slopeForce;
    [SerializeField] float slopeForceRayLength;

    private Controls controls;


    private void Start()
    {
        controls = new Controls();
        controls.Player.Jump.performed += Jump_performed;
        controls.Enable();

        controller = GetComponent<CharacterController>();
    }


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
    
    private void Jump_performed(InputAction.CallbackContext obj)
    {
        if (canJump)
        {
            jumpCounter -= 1;
            isJumping = true;
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    private void BouncePad()
    {
        velocity.y = Mathf.Sqrt(bouncePadHeight * -2f * gravity);
    }
  
    private void Update()
    {
        if (jumpCounter > 0)
            canJump = true;
        else
            canJump = false;

        if (onBouncePad)
            BouncePad();

        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            isJumping = false;
        }

        var dirMove = controls.Player.Move.ReadValue<Vector2>();
     
        Vector3 move = transform.right * dirMove.x * moveSpeed + transform.forward * dirMove.y * moveSpeed + transform.up * velocity.y;

        controller.Move(move * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if ((dirMove.x != 0 || dirMove.y != 0) && OnSlope())
        controller.Move(Vector3.down * controller.height / 2 * slopeForce * Time.deltaTime);
    }

     
    private void LateUpdate()
    { 
        if (controller.isGrounded)
            jumpCounter = jumpCount;
    }
}
