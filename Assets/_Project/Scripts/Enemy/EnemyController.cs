using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    private EnemyMovementStateMachine movementSM;
    private EnemySearchingStateMachine searchingSM;

    [Header("Visual Check")] 
    [SerializeField] private float radius;
    [SerializeField] private Vector3 rayOffset;
    [SerializeField] private float maxDistance;

    private void Start()
    {
        movementSM = new EnemyMovementStateMachine(this);
        movementSM.Initialize(movementSM.patrolState);

        searchingSM = new EnemySearchingStateMachine(this);
        searchingSM.Initialize(searchingSM.sightCheck);
    }
    
    private void Update()
    {
        movementSM.currentState?.Execute(agent);
        searchingSM.currentState?.Execute(transform.position);

        if (!searchingSM.currentState.stimuli) return;
        
        movementSM.SwitchStates(movementSM.chaseState);
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position + rayOffset, transform.forward * maxDistance, Color.red);
    }
}
