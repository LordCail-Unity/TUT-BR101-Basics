using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody _rigidBody;

    public float forwardForce = 4000f;
    public float sidewaysForce = 50f;
    public bool movePlayer;

    private void Start()
    {
        movePlayer = false;
    }

    // Unity prefers FixedUpdate() method instead of Update() for physics 
    void FixedUpdate()
    {

        if (movePlayer == true)
        {
            // Add a forward force
            _rigidBody.AddForce(0, 0, forwardForce * Time.deltaTime);

            // This is how Brackeys set up his basic movement system.
            // We will need to research the best way to set up simple move systems.
            // Then we want to add super simple mobile touch screen input.
            if (Input.GetKey("d"))
            {
                _rigidBody.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }

            if (Input.GetKey("a"))
            {
                _rigidBody.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
        }

    }

}
