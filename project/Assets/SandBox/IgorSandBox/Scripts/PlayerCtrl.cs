using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public float moveSpeed;
    
    private Vector3 moveInput;
    private Vector3 moveVelocity;


    private Controls controls;

    private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        controls.Enable();

    }

    // Update is called once per frame
    void Update()
    {
        var dirMove = controls.Player.Move.ReadValue<Vector2>();

        moveInput = new Vector3(dirMove.x * moveSpeed, rb.velocity.y, dirMove.y * moveSpeed);


       
        Vector3 playerDirection = Vector3.right * dirMove.x + Vector3.forward * dirMove.y;
        if (playerDirection.sqrMagnitude > 0.0f)
            transform.rotation = Quaternion.LookRotation(playerDirection);
    }

    private void FixedUpdate()
    {
        rb.velocity = moveInput;             //add velocity to player
    }
}
