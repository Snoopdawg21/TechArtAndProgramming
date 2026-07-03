using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerMovementStateMachine movementSM;
    private Vector3 spawnPos;

    private void Start()
    {
        movementSM = new PlayerMovementStateMachine(this);
        movementSM.Initialize(movementSM.aliveState);

        spawnPos = transform.position;
    }

    private void FixedUpdate()
    {
        movementSM.currentState?.Execute();
    }

    public void HitEnemy()
    {
        transform.position = spawnPos;
        movementSM.currentState?.Exit();
    }
}
