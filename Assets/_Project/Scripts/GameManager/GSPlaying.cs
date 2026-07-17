using UnityEngine;

public class GSPlaying : IGameStates
{
    public void Enter(GameManager manager)
    {
        Time.timeScale = 1;
        manager.spawn.ScatterKeys();
    }

    public void Execute()
    {
        
    }

    public void Exit()
    {
        
    }
}
