using UnityEngine;
using UnityEngine.AI;

public class EMSPatrol : IEnemyMovementStates
{
    private GameObject[] patrolPointsOBJ;
    private Vector3[] pointsPos;
    private int counter;
    private float checkTimer;
    
    public void Enter()
    {
        if (pointsPos != null) return;
        
        patrolPointsOBJ = GameObject.FindGameObjectsWithTag("Patrol Point");
        pointsPos = new Vector3[patrolPointsOBJ.Length];

        foreach (GameObject point in patrolPointsOBJ)
        {
            pointsPos[counter] = point.transform.position;
            counter++;
        }
        
        counter = 0;
    }

    public void Execute(NavMeshAgent agent)
    {
        checkTimer += Time.deltaTime;
        if (agent.remainingDistance > agent.stoppingDistance || checkTimer < 2) return;
        
        counter++;
        if (counter >= pointsPos.Length)
            counter = 0;
        
        agent.SetDestination(pointsPos[counter]);
        checkTimer = 0;
    }

    public void Exit()
    {
        counter = 0;
    }
}
