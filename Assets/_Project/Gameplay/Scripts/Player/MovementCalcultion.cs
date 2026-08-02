using UnityEngine;
using UnityEngine.InputSystem;

public class MovementCalculation : MonoBehaviour
{
    [SerializeField] private CharacterController cc;
    [SerializeField] private float movementSpeed;
    [SerializeField] private Vector2 direction;
    private Vector3 movementX;
    private Vector3 movementZ;
    private float sprintModifier;
    
    [Header("Ground Check")]
    [SerializeField] private float gravityScale;
    [SerializeField] private Vector3 groundCheckOffset;
    [SerializeField] private float groundCheckDistance;
    private Vector3 gravityMovement;

    [Header("Camera")] 
    [SerializeField] private GameObject camObject;
    [SerializeField] private Camera playerCam;
    [SerializeField] private Vector2 mousePosition;
    [SerializeField] private float sensitivity;
    private float xRotation;
    private float yRotation;
    private float lookX;
    private float lookY;

    private bool paused;

    private PlayerController control;
    
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

    public void OnPause(InputValue value)
    {
        control.gm.PauseGame();
    }

    public void OnSprint(InputValue value)
    {
        sprintModifier = value.Get<float>();
    }

    private void Start()
    {
        control = gameObject.GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (Time.timeScale == 0) return;
        
        CalculateMouseMovement();
    }

    private void FixedUpdate()
    {
        CalculateMovement();
    }
    

    private void CalculateMovement()
    {
        movementX = transform.forward * direction.x;
        movementZ = transform.right * direction.y;

        var movement = (movementX + movementZ) * (movementSpeed * Time.fixedDeltaTime * (sprintModifier + 1));

        cc.Move(movement);
        
        if(groundCheck())
            gravityMovement = Vector3.zero;
        else
            gravityMovement += Physics.gravity * (movementSpeed * Time.fixedDeltaTime);
        
        cc.Move(gravityMovement);
        
    }
    
    private void CalculateMouseMovement()
    {
        lookX = mousePosition.x * sensitivity;
        lookY = mousePosition.y * sensitivity;
        
        xRotation -= lookY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        
        playerCam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        
        transform.Rotate(Vector3.up * lookX);
    }

    private bool groundCheck()
    {
        return Physics.Raycast(transform.position + groundCheckOffset, Vector3.down, groundCheckDistance);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position + groundCheckOffset, Vector3.down * groundCheckDistance);
        
        Gizmos.color = groundCheck() ? Color.blue : Color.red;
    }
}
