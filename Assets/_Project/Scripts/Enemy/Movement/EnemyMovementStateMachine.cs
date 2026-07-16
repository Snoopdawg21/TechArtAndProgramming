using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementStateMachine
{
    public IEnemyMovementStates currentState {get; private set;}

    public EMSPatrol patrolState;
    public EMSChase chaseState;

    public EnemyMovementStateMachine(EnemyController enemy)
    {
        patrolState = new EMSPatrol();
        chaseState = new EMSChase();
    }
    
    public void SwitchStates(IEnemyMovementStates state, NavMeshAgent agent)
    {
        currentState?.Exit();
        currentState = state;
        currentState.Enter(agent);
    }
}
