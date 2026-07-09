using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    private PlayerController playerController;
    private PlayerMovementStateMachine movementSM;
    
    private void OnTriggerEnter(Collider col)
    {
        if(!col.GetComponent<PlayerController>()) return;
        Debug.Log(col.name);
        playerController = col.GetComponent<PlayerController>();
        
        Debug.Log("touched");
        playerController.HitEnemy();
        gameObject.GetComponent<EnemyController>().movementSM.SwitchStates(gameObject.GetComponent<EnemyController>().movementSM.patrolState);
    }
}
