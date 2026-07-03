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
    [SerializeField] private float stimulusMaxTimer;

    public Vector3 rayOffset { get; private set; } = new Vector3(0, 1, 0);
    public float radius { get; private set; } = 0.5f;

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

        if (stimuliTimer > stimulusMaxTimer && stateToggle)
        {
            movementSM.SwitchStates(movementSM.patrolState);
            stateToggle = false;
            return;
        }
        
        if (!playerCheck.VisualCheck(transform.position)) return;
        
        stimuliTimer = 0;

        if (stateToggle) return;
        
        stateToggle = true;
        movementSM.SwitchStates(movementSM.chaseState);
    }
    
    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position + rayOffset, Vector3.forward, Color.red);
    }
}
