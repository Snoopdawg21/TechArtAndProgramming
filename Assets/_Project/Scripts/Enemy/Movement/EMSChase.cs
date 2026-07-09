using UnityEngine;
using UnityEngine.AI;

public class EMSChase : IEnemyMovementStates
{
    private Transform playerPos;
    private float enemySpeed = 5;
    
    public void Enter()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void Execute(NavMeshAgent agent)
    {
        agent.SetDestination(playerPos.position);
        
        if (agent.speed == enemySpeed) return;
        
        agent.speed = enemySpeed;
    }

    public void Exit()
    {
        playerPos = null;
    }
}
