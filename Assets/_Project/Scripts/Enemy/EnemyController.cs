using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    private EnemyMovementStateMachine movementSM;

    private void Start()
    {
        movementSM = new EnemyMovementStateMachine(this);
        movementSM.Initialize(movementSM.patrolState);
    }
    
    private void Update()
    {
        movementSM.currentState?.Execute(agent);
    }
}
