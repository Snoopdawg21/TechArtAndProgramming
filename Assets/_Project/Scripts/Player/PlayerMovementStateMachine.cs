using UnityEngine;

public class PlayerMovementStateMachine
{
    public IPlayerMovementStates currentState { get; private set; }

    public PMSAlive aliveState;
    public PMSDead deadState;
    public PMSRespawn respawnState;
    
    public PlayerMovementStateMachine(PlayerController player)
    {
        aliveState = new PMSAlive(player);
        deadState = new PMSDead(player);
        respawnState = new PMSRespawn(player);
    }

    public void SwitchStates(IPlayerMovementStates state)
    {
        if (state == currentState) return;
        
        currentState?.Exit();
        currentState = state;
        currentState?.Enter();
    }
}
