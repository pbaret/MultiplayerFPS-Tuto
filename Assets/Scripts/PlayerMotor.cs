using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Vector3 cameraRotation = Vector3.zero;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Gets the movement vector
    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    // Gets the rotational vector
    public void Rotate(Vector3 _rotation)
    {
        rotation = _rotation;
    }

    public void RotateCamera(Vector3 _camRot)
    {
        cameraRotation = _camRot;
    }

    private void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }

    // Perform movement based on velocity variable
    private void PerformMovement()
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(transform.position + velocity * Time.fixedDeltaTime);
        }
    }

    // Perform rotation
    private void PerformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));

        if (cam != null)
        {
            cam.transform.Rotate(-cameraRotation);
        }
    }
}
