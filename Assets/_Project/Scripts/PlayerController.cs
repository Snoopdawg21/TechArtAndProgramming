using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float movementSpeed;
    [SerializeField] private Vector2 direction;
    private Vector3 movement;

    [Header("Camera")] 
    [SerializeField] private GameObject camera;

    [SerializeField] private Vector3 rotation;
    [SerializeField] private float sensitivity;
    
    public void OnForward(InputValue value)
    {
        direction.x = value.Get<float>();
    }

    public void OnSideways(InputValue value)
    {
        direction.y = value.Get<float>();
    }
    
    void FixedUpdate()
    {
        CalculateMouseMovement();
        CalculateMovement();
    }

    private void CalculateMovement()
    {
        rb.linearVelocity = (Vector3.forward * direction.x + Vector3.right * direction.y) * movementSpeed;
    }

    private void CalculateMouseMovement()
    {
        rotation.x += Input.GetAxis("Mouse X") * sensitivity;
        rotation.y += Input.GetAxis("Mouse Y") * -1 * sensitivity;
        
        camera.transform.eulerAngles = rotation;

        transform.forward = camera.transform.forward;
    }
    
}
