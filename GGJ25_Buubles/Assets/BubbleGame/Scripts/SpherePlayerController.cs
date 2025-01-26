using UnityEngine;

public class SpherePlayerController : MonoBehaviour
{
    [Header("Player Movement")]
    public Rigidbody sphereRigidbody;
    public float moveSpeed = 50f;
    public float momentumDampening = .25f;
    private float xInput;
    private float yInput;
    private Vector3 moveDirection;

    [Header("Camera Movement")]
    public Transform cameraX;
    public Transform cameraY;
    public float xSensitivity = 500f;
    public float ySensitivity = 500f;
    public float yClampMin = -90f;
    public float yClampMax = 90f;
    private float mouseX;
    private float mouseY;
    private float camYRotation;

    private void Awake()
    {
        if (sphereRigidbody == null)
            sphereRigidbody = GetComponentInChildren<Rigidbody>();
    }

    private void Start()
    {
        sphereRigidbody.linearDamping = momentumDampening;

        // Lock and hide the cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        MoveSphere();
        MoveCamera();
    }

    private void MoveSphere()
    {
        // Get Input
        xInput = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        yInput = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        // Get movement direction from input
        moveDirection = (cameraX.right * xInput) + (cameraX.forward * yInput);

        // Apply the movement to the sphere
        sphereRigidbody.AddForce(moveDirection);
    }

    private void MoveCamera()
    {
        // Get Input
        mouseX = Input.GetAxis("Mouse X") * xSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * ySensitivity * Time.deltaTime;

        // Horizontal movement
        cameraX.Rotate(Vector3.up * mouseX);

        // Vertical movement
        camYRotation -= mouseY;
        camYRotation = Mathf.Clamp(camYRotation, yClampMin, yClampMax);
        cameraY.localRotation = Quaternion.Euler(camYRotation, 0, 0);
    }

}
