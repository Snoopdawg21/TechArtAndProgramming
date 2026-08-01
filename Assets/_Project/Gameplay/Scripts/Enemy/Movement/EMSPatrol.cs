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

        randomNum = Random.Range(0, pointsPos.Length);
        
        for (var i = 0; i < pointsPos.Length; i++)
        {
            pointsPos[i] = Vector3.zero;
        }

        for (var i = 0; i < pointsPos.Length; i++)
        {
            while(pointsPos[randomNum] != Vector3.zero)
            {
                randomNum = Random.Range(0, patrolPointsOBJ.Length);
            }
            
            pointsPos[i] = patrolPointsOBJ[i].transform.position;
        }
        
        counter = Random.Range(0, pointsPos.Length);
        
        agent.speed = enemySpeed;
        
        agent.gameObject.GetComponent<FootstepSoundManager>().soundTimer = 0.5f;
    }

    public void Execute(NavMeshAgent agent)
    {
        checkTimer += Time.deltaTime;
        
        if (agent.remainingDistance > agent.stoppingDistance || checkTimer < 2) return;

        NewPoint(agent);
    }

    public void Exit()
    {
        
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
