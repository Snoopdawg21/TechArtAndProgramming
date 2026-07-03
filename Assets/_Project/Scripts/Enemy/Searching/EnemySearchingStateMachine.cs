using UnityEngine;

public class EnemySearchingStateMachine
{
    public IEnemySearchStates currentState { get; private set;}

    public ESSSight sightCheck;

    public EnemySearchingStateMachine(EnemyController enemy)
    {
        sightCheck = new ESSSight();
    }

    public void Initialize(IEnemySearchStates state)
    {
        currentState = state;
        currentState.Enter();
    }
}
