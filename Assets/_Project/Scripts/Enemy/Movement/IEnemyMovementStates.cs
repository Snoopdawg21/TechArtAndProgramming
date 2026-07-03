using UnityEngine.AI;

public interface IEnemyMovementStates
{
    void Enter();
    void Execute(NavMeshAgent agent);
    void Exit();
}
