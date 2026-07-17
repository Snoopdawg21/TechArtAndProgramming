using UnityEngine;

public class GSWin : IGameStates
{
    private UIManager ui;
    
    public void Enter(GameManager manager)
    {
        Time.timeScale = 0;
        
        ui = GameObject.FindGameObjectWithTag("GameController").GetComponent<UIManager>();
        ui.Win();
    }

    public void Execute()
    {
        
    }

    public void Exit()
    {
        
    }
}
