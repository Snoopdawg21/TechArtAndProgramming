using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class PMSAlive : IPlayerMovementStates
{
    private PlayerController player;

    public PMSAlive(PlayerController playerController)
    {
        this.player = playerController;
    }
    
    public void Enter()
    {
        player.isAlive = true;
        player.calc.enabled = true;
    }

    public void Execute()
    {
        
    }

    public void Exit()
    {
        
    }
}
