using UnityEngine;
using UnityEngine.AI;

public class EMSChase : IEnemyMovementStates
{
    private Transform playerPos;
    
    public void Enter()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
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
