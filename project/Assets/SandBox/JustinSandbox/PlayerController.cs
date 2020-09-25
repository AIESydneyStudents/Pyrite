using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;

    Vector3 velocity;
    public float gravity = -9.81f;
    public float jumpHeight = 3.0f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    public Controls controls;
    private int extraJumpCount = 1;
    private int jumpCount;
    bool canJump;


    private void Start()
    {
        controls = new Controls();
        controls.Player.Jump.performed += Jump_performed;
        controls.Enable();

    }


    private void Jump_performed(InputAction.CallbackContext obj)
    {
        if (canJump)
        {
            jumpCount -= 1;
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded)
            jumpCount = extraJumpCount;

        if (jumpCount > 0)
            canJump = true;
        else
            canJump = false;



        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        var dirMove = controls.Player.Move.ReadValue<Vector2>();

        Vector3 move = transform.right * dirMove.x + transform.forward * dirMove.y;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
