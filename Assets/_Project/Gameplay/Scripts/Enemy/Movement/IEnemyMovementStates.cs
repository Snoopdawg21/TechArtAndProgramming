using UnityEngine.AI;

public interface IEnemyMovementStates
{
    void Enter(NavMeshAgent agent);
    void Execute(NavMeshAgent agent);
    void Exit();
}
