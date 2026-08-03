using UnityEngine.AI;

public class EnemyMovementStateMachine
{
    public IEnemyMovementStates currentState {get; private set;}

    public EMSPatrol patrolState;
    public EMSChase chaseState;
    public EMSInvestigate investigateState;

    public EnemyMovementStateMachine(EnemyController enemy)
    {
        patrolState = new EMSPatrol();
        chaseState = new EMSChase();
        investigateState = new EMSInvestigate();
    }
    
    public void SwitchStates(IEnemyMovementStates state, NavMeshAgent agent)
    {
        currentState?.Exit();
        currentState = state;
        currentState.Enter(agent);
    }
}
