using UnityEngine;

public class GSPlaying : IGameStates
{
    private GameManager gm;
    
    public void Enter(GameManager manager)
    {
        Time.timeScale = 1;
        manager.spawn.ScatterKeys();

        gm = manager;
        
        gm.playerControl.enabled = true;
    }

    public void Execute()
    {
        
    }

    public void Exit()
    {
        gm.playerControl.enabled = false;
    }
}
