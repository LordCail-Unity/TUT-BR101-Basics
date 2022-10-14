using UnityEngine;

public class CameraControllerBmo : MonoBehaviour
{
    
    public GameObject target; // Update to get GameObject with "Player" tag so we can use a camera prefab in multiple scenes
    public float xOffset, yOffset, zOffset;

    private void Update()
    {
        transform.position = target.transform.position + new Vector3(xOffset, yOffset, zOffset);
        transform.LookAt(target.transform.position); 
        // Need to fix so the camera looks in the direction the player is moving
        // This is clear in test Level 03 where you go backwards
    }

}