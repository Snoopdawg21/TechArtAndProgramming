using UnityEngine;

public class PlayerMovementStateMachine
{
    public IPlayerMovementStates currentState { get; private set; }

    public PMSAlive aliveState;
    
    public PlayerMovementStateMachine(PlayerController player)
    {
        aliveState = new PMSAlive();
    }

    public void Initialize(IPlayerMovementStates state)
    {
        currentState = state;
        aliveState.Enter();
    }

    public void SwitchStates(IPlayerMovementStates state)
    {
        currentState?.Exit();
        currentState = state;
        currentState.Enter();
    }
}
