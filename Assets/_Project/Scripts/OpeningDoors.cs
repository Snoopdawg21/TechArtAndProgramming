using UnityEngine;

public class OpeningDoors : MonoBehaviour
{
    public int doorNum;
    
    [SerializeField] private float rotationSpeed;
    private bool canTurn;
    private float rotationAngle;

    private void Update()
    {
        if (!canTurn) return;
        Debug.Log(transform.rotation.eulerAngles.y);
        if (transform.rotation.eulerAngles.y >= 90) return;
        
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
    
    public void OpenDoor()
    {
        canTurn = true;
    }
}
