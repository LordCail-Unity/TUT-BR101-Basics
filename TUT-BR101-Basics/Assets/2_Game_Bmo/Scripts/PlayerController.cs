using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public Rigidbody _rigidbody;

    public float moveSpeed = 10f;
    public float horizontalSpeed = 2f;
    public float forwardThrust = 5f;

    public float groundLevel = 0f;
    public float jumpSpeed = 16f;
    private bool jumpPressed;
    private bool isJumping;


    // Awake is called when the game starts
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Good for handling inputs and animations
        ProcessInputs();
    }

    private void FixedUpdate()
    {
        // Good for handling physics based Movement
        Move();
    }

    private void ProcessInputs()
    {
        horizontalSpeed = Input.GetAxis("Horizontal");
        // forwardThrust = Input.GetAxis("Vertical");         
        //Ignore forwardThrust for now, use FixedForwardForce

        if (Input.GetButtonDown("Jump") == true)
        {
            jumpPressed = true;
        }
    }

    private void Move()
    {
        _rigidbody.AddForce(new Vector3(horizontalSpeed, 0f, forwardThrust) * moveSpeed);

        if(jumpPressed == true && isJumping == false)
        {
            _rigidbody.AddForce(new Vector3(0f, jumpSpeed, 0f) * jumpSpeed);
            jumpPressed = false;
        }
    }

    private void Jumping()
    {
        if (transform.position.y > groundLevel)
        {
            isJumping = true;
        }
    }

}
