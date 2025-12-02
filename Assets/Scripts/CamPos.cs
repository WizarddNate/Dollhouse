using UnityEngine;

public class CamPos : MonoBehaviour
{
    public Transform cameraPos;

    private void Update()
    {
        //get transform of camera position
        cameraPos = GameObject.Find("CameraPos").transform;

        //set camera to CameraPos position
        transform.position = cameraPos.position;
    }
}
