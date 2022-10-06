using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody _rigidBody;

    public float forwardForce = 4000f;
    public float sidewaysForce = 50f;
    public float killZone = -1f;

   
    // Unity prefers FixedUpdate() method instead of Update() for physics 
    void FixedUpdate()
    {
        
        // Add a forward force
        _rigidBody.AddForce(0, 0, forwardForce * Time.deltaTime);

        if ( Input.GetKey("d"))
        {
            _rigidBody.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            
        }

        if (Input.GetKey("a"))
        {
            _rigidBody.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (_rigidBody.position.y < killZone)
        {
            FindObjectOfType<GameManager>().FellToDeath();
        }

    }

}
