using UnityEngine;

public class GSPause : IGameStates
{
    public void Enter(GameManager gm)
    {
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
    }

    public void Execute()
    {
        
    }

    public void Exit()
    {
        
    }
}
