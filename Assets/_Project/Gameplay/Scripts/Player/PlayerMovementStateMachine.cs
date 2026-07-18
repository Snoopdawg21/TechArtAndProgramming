public class PlayerMovementStateMachine
{
    public IPlayerMovementStates currentState { get; private set; }

    public PMSAlive aliveState;
    public PMSDead deadState;
    
    public PlayerMovementStateMachine(PlayerController player)
    {
        aliveState = new PMSAlive(player);
        deadState = new PMSDead(player);
    }

    public void SwitchStates(IPlayerMovementStates state)
    {
        if (state == currentState) return;
        
        currentState?.Exit();
        currentState = state;
        currentState?.Enter();
    }
}
