using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float numOfKeys;
    
    public PlayerMovementStateMachine movementSM;
    private Vector3 spawnPos;

    public bool isAlive = true;
    
    public MovementCalculation calc;

    private void Start()
    {
        calc = GetComponent<MovementCalculation>();
        movementSM = new PlayerMovementStateMachine(this);
        movementSM.SwitchStates(movementSM.aliveState);

        spawnPos = transform.position;
    }

    private void FixedUpdate()
    {
        movementSM.currentState?.Execute();
    }

    public void HitEnemy()
    {
        if (!isAlive) return;
        isAlive = false;
        
        transform.position = spawnPos;
        movementSM.SwitchStates(movementSM.deadState);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<CollectingKeys>())
        {
            numOfKeys++;
            Destroy(other.gameObject);
            return;
        }

        if (other.gameObject.GetComponent<OpeningDoors>())
        {
            if (numOfKeys < 1) return;
            
            numOfKeys--;
            other.gameObject.GetComponent<OpeningDoors>().OpenDoor();
        }
    }
}
