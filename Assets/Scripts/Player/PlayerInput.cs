using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public string moveXName = "Horizontal";
    public string moveZName = "Vertical";
    public string mouseXName = "Mouse X";
    public string mouseYName = "Mouse Y";
    public string fireButtonName = "Fire1";
    public string reloadButtonName = "Reload";

    public float moveX { get; private set; }
    public float moveZ { get; private set; }
    public float mouseX { get; private set; }
    public float mouseY { get; private set; }
    public bool fire { get; private set; }
    public bool reload { get; private set; }

    // private float sensitivityX = 15.0f;
    // private float sensitivityY = 15.0f;

    void Update()
    {
        moveX = Input.GetAxis(moveXName);
        moveZ = Input.GetAxis(moveZName);
        mouseX = Input.GetAxis(mouseXName);
        mouseY = Input.GetAxis(mouseYName);
        fire = Input.GetButton(fireButtonName);
        reload = Input.GetButtonDown(reloadButtonName);
    }
}
