using UnityEngine;

public class PMSDead : IPlayerMovementStates
{
    private PlayerController player;
    private bool respawning;
    private float respawnTimer;

    public PMSDead(PlayerController playerController)
    {
        this.player = playerController;
    }
    
    public void Enter()
    {
        player.calc.enabled = false;
        player.isAlive = false;
        
        respawnTimer = 0f;
    }

    public void Execute()
    {
        if (respawnTimer > 2)
        {
            player.movementSM.SwitchStates(player.movementSM.aliveState);
            Debug.Log("hi");
        }
        
        respawnTimer += Time.deltaTime;
    }

    public void Exit()
    {
        Debug.Log("exit");
    }
}
