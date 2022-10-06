using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    public PlayerMovement _movement;

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

}
