using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float mouseSenseX;
    public float mouseSenseY;

    public Transform player;

    float xRot = 0;
    //float yRot;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        //find player - set to find parent
        //player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {

        //get mouse input. Will probably have to be adjusted with new input manager
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * mouseSenseX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * mouseSenseY;

        //rotate camera up and down
        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -70f, 90f);
        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);

        //rotate player when looking left and right
        player.Rotate(Vector3.up * mouseX);
    }
}
