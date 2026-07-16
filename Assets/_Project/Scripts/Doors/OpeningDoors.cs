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
        if (doorBody.rotation.eulerAngles.y >= 90)
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
        //rotationSpeed *= -1;
        RotateDoor();
    }

    public void CloseDoor()
    {
        canTurn = true;
        rotationSpeed *= -1;
        RotateDoor();
    }
}
