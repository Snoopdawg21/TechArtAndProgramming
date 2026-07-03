using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    private EnemyMovementStateMachine movementSM;
    private PlayerCheck playerCheck;

    private float stimuliTimer;
    private bool stateToggle;

    [Header("Visual Check")] 
    [SerializeField] private float radius;
    [SerializeField] private Vector3 rayOffset;
    [SerializeField] private float maxDistance;

    private void Start()
    {
        movementSM = new EnemyMovementStateMachine(this);
        movementSM.Initialize(movementSM.patrolState);

        playerCheck = new PlayerCheck(this);
    }
    
    private void Update()
    {
        stimuliTimer += Time.deltaTime;
        movementSM.currentState?.Execute(agent);

        if (stimuliTimer > 5f && stateToggle)
        {
            movementSM.SwitchStates(movementSM.patrolState);
            stateToggle = false;
            return;
        }

        Debug.Log(playerCheck.VisualCheck(transform.position));
        if (!playerCheck.VisualCheck(transform.position)) return;
        
        stimuliTimer = 0;

        if (stateToggle) return;
        
        stateToggle = true;
        movementSM.SwitchStates(movementSM.chaseState);
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position + rayOffset, transform.forward * maxDistance, Color.red);
    }
}
