using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    private PlayerController playerController;
    private PlayerMovementStateMachine movementSM;
    
    private void OnCollisionEnter(Collision col)
    {
        if(!col.gameObject.GetComponent<PlayerController>()) return;
        Debug.Log(col.gameObject.name);
        playerController = col.gameObject.GetComponent<PlayerController>();
        
        
        Debug.Log("touched");
        playerController.HitEnemy();
    }
}
