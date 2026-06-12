public enum PlayerStates
{
    Idle,
    Walk
}

public interface IState
{
    public void Enter();
    public void Execute();
    public void Exit();
}

public class IdleState1 : IState
{
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

public class StateMachine1
{
    private PlayerController playerController;
    public IState CurrentState { get; private set; }

    public StateMachine1(PlayerController control)
    {
        playerController = control;
    }

    public void TransitionState(IState newState)
    {
        CurrentState?.Exit();
        CurrentState = newState;
        CurrentState?.Enter();
    }
    
}