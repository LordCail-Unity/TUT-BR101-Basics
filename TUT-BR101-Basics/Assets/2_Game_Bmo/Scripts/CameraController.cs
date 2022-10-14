using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject target;
    public float xOffset = 0;
    public float yOffset = 1f;
    public float zOffset = -4;


    private void Update()
    {
        transform.position = target.transform.position + new Vector3(xOffset, yOffset, zOffset);
        transform.LookAt(target.transform.position);
    }

}