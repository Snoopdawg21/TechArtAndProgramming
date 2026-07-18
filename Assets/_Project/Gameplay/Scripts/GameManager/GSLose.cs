using UnityEngine;

public class GSLose : IGameStates
{
    private UIManager ui;
    
    public void Enter(GameManager gm)
    {
        Time.timeScale = 0;
        
        gm.gameOver = true;
        
        ui = gm.gameObject.GetComponent<UIManager>();
        ui.Lose();
    }

    public void Exit()
    {
        
    }
}
