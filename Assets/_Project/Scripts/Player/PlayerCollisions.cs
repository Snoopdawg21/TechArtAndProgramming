using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    private PlayerController playerController;
    private PlayerMovementStateMachine movementSM;

    private void Start()
    {
        playerController = gameObject.GetComponent<PlayerController>();
    }
    
    private void OnTriggerEnter(Collider col)
    {
        if (!col.gameObject.CompareTag("enemy")) return;
        
        Debug.Log("touched");
        playerController.HitEnemy();
    }
}
