using UnityEngine;
using UnityEngine.AI;

public class EMSPatrol : IEnemyMovementStates
{
    private GameObject[] patrolPointsOBJ;
    private Vector3[] pointsPos;
    private int counter = 0;
    
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
        if (agent.remainingDistance > agent.stoppingDistance) return;
        
        counter++;
        if (counter >= pointsPos.Length - 1)
            counter = 0;
        
        agent.SetDestination(pointsPos[counter]);
        Debug.Log(pointsPos[counter]);
    }

    public void Exit()
    {
        counter = 0;
    }
}
