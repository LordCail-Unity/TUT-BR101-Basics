using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Vector3 offset;

    private void Update()
    {
    Vector3 cameraPos = Camera.main.transform.position;
    Camera.main.transform.position = Vector3.Lerp(new Vector3(cameraPos.x, cameraPos.y, cameraPos.z), transform.position + offset, 1);
    }

}

