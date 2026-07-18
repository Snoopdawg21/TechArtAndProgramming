using UnityEngine;

public class GSLose : IGameStates
{
    private UIManager ui;
    
    public void Enter(GameManager gm)
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        
        gm.gameOver = true;
        
        ui = gm.gameObject.GetComponent<UIManager>();
        ui.Lose();
    }

    public void Exit()
    {
        
    }
}
