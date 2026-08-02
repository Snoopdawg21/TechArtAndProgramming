using UnityEngine;

public class PMSDead : IPlayerMovementStates
{
    private PlayerController player;
    private bool respawning;
    private float respawnTimer;

    private int lives;

    public PMSDead(PlayerController playerController)
    {
        this.player = playerController;
        lives = 3;
    }
    
    public void Enter()
    {
        lives--;
        if (lives <= 0)
        {
            player.gm.LoseGame();
            return;
        }
        
        player.calc.enabled = false;
        player.isAlive = false;
        
        respawnTimer = 0f;
    }

    public void Execute()
    {
        if (respawnTimer > 2)
        {
            player.movementSM.SwitchStates(player.movementSM.aliveState);
        }
        
        respawnTimer += Time.deltaTime;
    }

    public void Exit()
    {
        
    }
}
