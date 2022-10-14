using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    public PlayerMovement _movement;

    //OnCollisionEnter vs OnTriggerEnter examples using object tags: 
    //With Collision, the player object will physically interact eg bounce off.
    //With Trigger, there is no physical interaction ie pass through.

    private void OnCollisionEnter(Collision collisionInfo)
    {
        
        if (collisionInfo.collider.tag == "Obstacle")
        {
            _movement.enabled = false;
            FindObjectOfType<GameManager>().Crashed();
            Debug.Log("PLAYERCOLLISION: Obstacle Collision");
        }

        if (collisionInfo.collider.tag == "FinishLine")
        {
            _movement.enabled = false;
            FindObjectOfType<GameManager>().LevelComplete();
            Debug.Log("PLAYERCOLLISION: Finish Line Collision");
        }

    }

    private void OnTriggerEnter(Collider colliderInfo)
    {
        if (colliderInfo.tag == "Killzone")
        {
            _movement.enabled = false;
            FindObjectOfType<GameManager>().FellToDeath();
            Debug.Log("PLAYERCOLLISION: Killzone Collision");
        }
    }


}
