using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    private EnemyMovementStateMachine movementSM;

    [Header("Visual Check")] 
    [SerializeField] private float radius;
    [SerializeField] private Vector3 rayOffset;
    [SerializeField] private float maxDistance;

    private void Start()
    {
        movementSM = new EnemyMovementStateMachine(this);
        movementSM.Initialize(movementSM.patrolState);
    }
    
    private void Update()
    {
        movementSM.currentState?.Execute(agent);
        Physics.SphereCast(transform.position + rayOffset, radius, Vector3.forward, out var hit, maxDistance);
        
        if (!hit.collider.CompareTag("Player") || hit.collider == null) return;
        
        movementSM.SwitchStates(movementSM.chaseState);
        Debug.Log("chasing");
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position + rayOffset, transform.forward * maxDistance, Color.red);
    }
}
