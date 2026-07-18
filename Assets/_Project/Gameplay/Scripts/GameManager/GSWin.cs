using UnityEngine;

public class GSWin : IGameStates
{
    private UIManager ui;
    
    public void Enter(GameManager manager)
    {
        Time.timeScale = 0;

        manager.gameOver = true;
        Cursor.lockState = CursorLockMode.None;
        
        ui = manager.gameObject.GetComponent<UIManager>();
        ui.Win();
    }

    public void Exit()
    {
        
    }
}
