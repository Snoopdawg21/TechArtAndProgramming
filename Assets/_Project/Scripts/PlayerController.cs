using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float movementSpeed;
    [SerializeField] private Vector2 direction;

    [Header("Camera")] 
    [SerializeField] private GameObject camObject;
    [SerializeField] private Camera playerCam;
    [SerializeField] private Vector3 rotation;
    [SerializeField] private float sensitivity;
    private Vector3 lookAtPoint;
    
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
        rotation = value.Get<Vector2>();
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
        Debug.Log($"screen width: {Screen.width}");
        Debug.Log($"Mouse Pos: {rotation}");
        
        if (rotation.x < Screen.width / 3)
        {
            camObject.transform.rotation = new Quaternion(camObject.transform.rotation.x - sensitivity, 0, 0, 0);
        }
        else if (rotation.x > Screen.width / 3)
        {
            camObject.transform.rotation = new Quaternion(camObject.transform.rotation.x + sensitivity, 0, 0, 0);
        }
    }
    
}
