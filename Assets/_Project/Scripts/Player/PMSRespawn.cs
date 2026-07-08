using UnityEngine;

public class PMSRespawn : IPlayerMovementStates
{
    private PlayerController player;
    
    public PMSRespawn(PlayerController playerController)
    {
        player = playerController;
    }
    
    public void Enter()
    {
        Debug.Log("hi");
    }

    public void Execute()
    {
        
    }

    public void Exit()
    {
        
    }
}
