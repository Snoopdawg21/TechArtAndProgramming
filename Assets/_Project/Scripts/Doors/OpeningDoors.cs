using UnityEngine;

public class OpeningDoors : MonoBehaviour
{
    public int doorNum;
    [SerializeField] private Transform doorBody;
    [SerializeField] private float rotationSpeed;
    private bool canTurn;

    private void Update()
    {
        if (!canTurn) return;
        Debug.Log(doorBody.localRotation.eulerAngles.y);
        if (doorBody.localRotation.eulerAngles.y >= 90|| 
            doorBody.localRotation.eulerAngles.y <= 0f)
        {
            canTurn = false;
            return;
        }
        
        RotateDoor();
    }

    private void RotateDoor()
    {
        doorBody.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
    
    public void OpenDoor()
    {
        Debug.Log("opening");
        canTurn = true;
        rotationSpeed *= -1;
        RotateDoor();
        doorBody.eulerAngles = new Vector3(0, doorBody.localRotation.eulerAngles.y + 0.5f, 0);
    }

    public void CloseDoor()
    {
        canTurn = true;
        rotationSpeed *= -1;
        RotateDoor();
        doorBody.eulerAngles = new Vector3(0, doorBody.localRotation.eulerAngles.y - 0.5f, 0);
    }
}
