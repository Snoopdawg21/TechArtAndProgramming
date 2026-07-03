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
    
    public void Initialize(IEnemyMovementStates state)
    {
        currentState = state;
        currentState.Enter();
    }

    public void SwitchStates(IEnemyMovementStates state)
    {
        currentState.Exit();
        currentState = state;
        currentState.Enter();
    }
}
