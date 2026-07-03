using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerMovementStateMachine movementSM;

    private void Start()
    {
        movementSM = new PlayerMovementStateMachine(this);
        movementSM.Initialize(movementSM.aliveState);
    }

    private void Update()
    {
        movementSM.currentState?.Execute();
    }
}
