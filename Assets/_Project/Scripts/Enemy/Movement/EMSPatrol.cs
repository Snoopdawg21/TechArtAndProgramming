using UnityEngine;
using UnityEngine.AI;

public class EMSPatrol : IEnemyMovementStates
{
    private GameObject[] patrolPointsOBJ;
    private Vector3[] pointsPos;
    private int counter;
    private int randomNum;
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
        randomNum = 0;
    }

    public void Execute(NavMeshAgent agent)
    {
        checkTimer += Time.deltaTime;
        if (agent.remainingDistance > agent.stoppingDistance || checkTimer < 2) return;

        while (randomNum == counter)
        {
            randomNum = Random.Range(0, pointsPos.Length);
        }

        counter = randomNum;
        
        agent.SetDestination(pointsPos[counter]);
        checkTimer = 0;
    }

    public void Exit()
    {
        counter = 0;
        randomNum = 0;
    }
}
