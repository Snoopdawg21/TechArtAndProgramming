using UnityEngine;
using UnityEngine.AI;

public class EMSChase : IEnemyMovementStates
{
    private Transform playerPos;
    private float enemySpeed = 7;
    
    public void Enter(NavMeshAgent agent)
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        
        agent.speed = enemySpeed;

        agent.gameObject.GetComponent<FootstepSoundManager>().soundTimer = 0.25f;
    }

    public void Execute(NavMeshAgent agent)
    {
        agent.SetDestination(playerPos.position);
    }

    public void Exit()
    {
        playerPos = null;
    }
}
