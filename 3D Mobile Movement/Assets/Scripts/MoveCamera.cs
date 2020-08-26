using UnityEngine;

public class MoveCamera : MonoBehaviour {

    public float speed = 3.5f;
    private float X;
    private float Y;

    public PlayerMovement pm;
    public Transform playerHead;
    public GameObject player;
    public Camera Cam;
    public float wallRunTilt = 25f;

    public joybutton2 moveArea;

    void Update() {
        transform.position = playerHead.transform.position;

        if (moveArea.Pressed)
        {
            transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * speed*-1, Input.GetAxis("Mouse X") * speed, 0));
            X = transform.rotation.eulerAngles.x;
            Y = transform.rotation.eulerAngles.y;
            transform.rotation = Quaternion.Euler(X, Y, 0);
        }
}
}