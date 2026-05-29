using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float movementSpeed;
    [SerializeField] private Vector2 direction;
    [SerializeField] private float gravityScale;
    [SerializeField] private Vector3 groundCheckOffset;
    [SerializeField] private float groundCheckDistance;
    private Vector3 movementX;
    private Vector3 movementZ;

    [Header("Camera")] 
    [SerializeField] private GameObject camObject;
    [SerializeField] private Camera playerCam;
    [SerializeField] private Vector2 mousePosition;
    [SerializeField] private float sensitivity;
    private float xRotation;
    private float yRotation;
    private float lookX;
    private float lookY;
    
    public void OnForward(InputValue value)
    {
        direction.x = value.Get<float>();
    }

    public void OnSideways(InputValue value)
    {
        direction.y = value.Get<float>();
    }

    public void OnMousePos(InputValue value)
    {
        mousePosition = value.Get<Vector2>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    void FixedUpdate()
    {
        CalculateMouseMovement();
        CalculateMovement();
    }

    private void CalculateMovement()
    {
        movementX = transform.forward * direction.x;
        movementZ = transform.right * direction.y;
        
        Vector3 movement = (movementX + movementZ) * (movementSpeed * Time.deltaTime);
        
        rb.linearVelocity = movement;
        
        if(!groundCheck())
            rb.AddForce(Physics.gravity * gravityScale, ForceMode.Acceleration);
    }
    
    private void CalculateMouseMovement()
    {
        lookX = mousePosition.x * sensitivity * Time.deltaTime;
        lookY = mousePosition.y * sensitivity * Time.deltaTime;
        
        xRotation -= lookY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        
        playerCam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        
        transform.Rotate(Vector3.up * lookX);
    }

    private bool groundCheck()
    {
        return Physics.SphereCast(groundCheckOffset, groundCheckDistance, Vector3.down, out RaycastHit hit);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(groundCheckOffset, groundCheckDistance);
        
        Gizmos.color = groundCheck() ? Color.blue : Color.red;
    }
}
