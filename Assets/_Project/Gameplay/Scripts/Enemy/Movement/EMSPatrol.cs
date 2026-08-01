using UnityEngine;
using UnityEngine.AI;

public class EMSPatrol : IEnemyMovementStates
{
    private GameObject[] patrolPointsOBJ;
    private Vector3[] pointsPos;
    private int counter;
    private int randomNum;
    private float checkTimer;

    private float enemySpeed = 2.5f;
    
    public void Enter(NavMeshAgent agent)
    {
        if (pointsPos != null) return;
        
        patrolPointsOBJ = GameObject.FindGameObjectsWithTag("Patrol Point");
        pointsPos = new Vector3[patrolPointsOBJ.Length];

        foreach (var point in patrolPointsOBJ)
        {
            pointsPos[counter] = point.transform.position;
            counter++;
        }
        
        counter = 0;
        randomNum = 0;
        
        agent.speed = enemySpeed;
        
        agent.gameObject.GetComponent<FootstepSoundManager>().soundTimer = 0.5f;
    }

    public void Execute(NavMeshAgent agent)
    {
        checkTimer += Time.deltaTime;
        if (checkTimer > 75f)
        {
            NewPoint(agent);
            return;
        }
        
        if (agent.remainingDistance > agent.stoppingDistance || checkTimer < 2) return;

        NewPoint(agent);
    }

    public void Exit()
    {
        counter = 0;
        randomNum = 0;
    }

    private void NewPoint(NavMeshAgent agent)
    {
        if (counter >= pointsPos.Length)
            counter = 0;
        else
            counter++;
        
        agent.SetDestination(pointsPos[counter]);
        checkTimer = 0;
    }
}
