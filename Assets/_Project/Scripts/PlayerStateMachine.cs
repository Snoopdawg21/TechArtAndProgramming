public class PlayerStateMachine
{
    private PlayerController playerController;
    //private IdleState idleState = new IdleState(playerController);
    
    public IPlayerStates CurrentState { get; private set; }
    
    public PlayerStateMachine(PlayerController controller)
    {
        playerController = controller;
    }

    public void SwitchStates(IPlayerStates newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }
}

class IdleState : IPlayerStates
{
    PlayerController playerController;
    public IdleState(PlayerController controller)=>playerController = controller;
    
    public void Enter()
    {
        
    }

    public void Execute()
    {
        
    }

    public void Exit()
    {
        
    }
}