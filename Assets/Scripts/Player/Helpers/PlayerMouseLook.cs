using UnityEngine;

public class PlayerMouseLook
{
    private float xRotation = 0f;
    private Camera cam;
    private Transform transform;
    private float mouseSensitivity;

    public PlayerMouseLook(PlayerReferences playerRef, Transform playerTransform)
    {
        cam = playerRef.PlayerCamera;
        transform = playerTransform;
        mouseSensitivity = playerRef.GameSettings.MouseSensitivity;
    }

    public void MouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    public void LookAhead()
    {
        cam.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
    }
}
