using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public NavMeshAgent agent { get; private set; }
    public EnemyMovementStateMachine movementSM;
    private PlayerCheck playerCheck;

    private float stimuliTimer;
    private bool stateToggle;

    public EnemyManager em { get; private set; }
    private FootstepSoundManager fssm;

    [Header("Visual Check")] 
    [SerializeField] private float stimulusMaxTimer;

    public Vector3 rayOffset {get;} = new (0, 1, 0);
    public float radius { get; private set; } = 0.5f;

    private void Awake()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
    }
    
    private void Start()
    {
        movementSM = new EnemyMovementStateMachine(this);
        movementSM.SwitchStates(movementSM.patrolState, agent);
        
        playerCheck = new PlayerCheck(this);
        
        fssm = gameObject.GetComponent<FootstepSoundManager>();

        em = GameObject.FindGameObjectWithTag("GameController").GetComponent<EnemyManager>();
    }
    
    private void Update()
    {
        stimuliTimer += Time.deltaTime;
        movementSM.currentState?.Execute(agent);

        if (stimuliTimer > stimulusMaxTimer && stateToggle)
        {
            movementSM.SwitchStates(movementSM.patrolState, agent);
            stateToggle = false;
            return;
        }
        
        if (!playerCheck.VisualCheck(transform)) return;
        
        stimuliTimer = 0;

        if (stateToggle) return;
        
        stateToggle = true;
        movementSM.SwitchStates(movementSM.chaseState, agent);
    }

    private void OnTriggerEnter(Collider col)
    {
        
        if (!col.GetComponent<OpeningDoors>()) return;
        col.GetComponent<OpeningDoors>().OpenDoor();
    }
    
    private void OnTriggerExit(Collider col)
    {
        if (!col.GetComponent<OpeningDoors>()) return;
        col.GetComponent<OpeningDoors>().CloseDoor();
    }
    
    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position + rayOffset, Vector3.forward, Color.red);
    }
}
