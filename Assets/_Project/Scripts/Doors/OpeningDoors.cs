using UnityEngine;

public class OpeningDoors : MonoBehaviour
{
    public int doorNum;
    
    [SerializeField] private float rotationSpeed;
    private bool canTurn;

    private void Update()
    {
        if (!canTurn) return;
        if (transform.rotation.eulerAngles.y >= 90 || transform.rotation.eulerAngles.y <= 0)
        {
            canTurn = false;
            return;
        }
        
        RotateDoor();
    }

    private void RotateDoor()
    {
        transform.Rotate(0, Mathf.Clamp(rotationSpeed * Time.deltaTime, 0, 90), 0);
    }
    
    public void OpenDoor()
    {
        canTurn = true;
        rotationSpeed *= -1;
        RotateDoor();
    }

    public void CloseDoor()
    {
        canTurn = true;
        rotationSpeed *= -1;
        RotateDoor();
    }
}
