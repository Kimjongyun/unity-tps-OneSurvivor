using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Transform playerBody;
    public Transform cameraRig;
    public float mouseSensitivity = 10f;
    private float rotationX = 0f;

    private PlayerInput playerInput;

    void Start()
    {
        playerInput = FindAnyObjectByType<PlayerInput>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = playerInput.mouseX * mouseSensitivity;
        float mouseY = playerInput.mouseY * mouseSensitivity;

        // 좌우 회전
        playerBody.Rotate(Vector3.up * mouseX);

        // 상하 회전
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -60f, 60f); // 위아래 제한
        cameraRig.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
    }
}
