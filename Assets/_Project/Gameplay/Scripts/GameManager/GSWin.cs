using UnityEngine;

public class GSWin : IGameStates
{
    private UIManager ui;
    private GameManager gm;
    
    public void Enter(GameManager manager)
    {
        Time.timeScale = 0;

        manager.gameOver = true;
        Cursor.lockState = CursorLockMode.None;
        
        ui = manager.gameObject.GetComponent<UIManager>();
        ui.Win();
    }

    public void Execute()
    {
        
    }

    public void Exit()
    {
        
    }
}
