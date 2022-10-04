using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    public PlayerMovement movement;

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            movement.enabled = false;
            FindObjectOfType<GameManager>().RestartLevel();
        }
        if (collisionInfo.collider.tag == "FinishLine")
        {
            movement.enabled = false;
            FindObjectOfType<GameManager>().LevelComplete();
        }
    }

}
