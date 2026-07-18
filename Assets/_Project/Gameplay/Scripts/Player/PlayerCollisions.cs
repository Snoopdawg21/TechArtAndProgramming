using UnityEngine;
using UnityEngine.AI;

public class PlayerCollisions : MonoBehaviour
{
    private PlayerController playerController;
    private EnemyController controller;
    
    private void OnTriggerEnter(Collider col)
    {
        if(!col.GetComponent<PlayerController>()) return;
        controller = gameObject.GetComponent<EnemyController>();
        
        Debug.Log(col.name);
        playerController = col.GetComponent<PlayerController>();
        
        Debug.Log("touched");
        playerController.HitEnemy();
        controller.em.CaughtPlayer();
    }
}
