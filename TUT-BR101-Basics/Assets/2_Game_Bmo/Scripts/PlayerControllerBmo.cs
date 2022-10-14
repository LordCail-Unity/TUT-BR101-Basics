using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Bmo TUT: https://www.youtube.com/watch?v=BwPT7huwjn4

public class PlayerControllerBmo : MonoBehaviour
{

    public Rigidbody rb;

    public float moveSpeed = 10f;
    private float xInput;
    private float zInput;


    // Awake is called when the game starts
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
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
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");         
    }

    private void Move()
    {
        rb.AddForce(new Vector3(xInput, 0f, zInput) * moveSpeed);
    }

}
