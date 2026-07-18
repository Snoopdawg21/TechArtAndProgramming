public class GameStateManager
{
    private IGameStates currentState;
    
    private GameManager manager;

    public GSPlaying playingState;
    public GSWin winState;
    public GSPause pauseState;
    public GSLose loseState;
    
    public GameStateManager(GameManager gm)
    {
        playingState = new GSPlaying();
        winState = new GSWin();
        pauseState = new GSPause();
        loseState = new GSLose();
        
        manager = gm;
    }

    public void SwitchStates(IGameStates state)
    {
        currentState?.Exit();
        currentState = state;
        currentState.Enter(manager);
    }
}
