using UnityEngine;

public class PMSAlive : IPlayerMovementStates
{
    private MovementCalculation calc;
    private PlayerCollisions collider;
    
    public void Enter()
    {
        calc = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementCalculation>();
        collider = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerCollisions>();
        calc.enabled = true;
        collider.enabled = true;
    }

    public void Execute()
    {
        
    }

    public void Exit()
    {
        calc.enabled = false;
        collider.enabled = false;
    }
}
