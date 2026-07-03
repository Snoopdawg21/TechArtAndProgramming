using UnityEngine;

public class ESSSight : IEnemySearchStates
{
    private Vector3 rayOffset;
    private float maxDistance;
    
    public bool stimuli { get; set; }
    
    public void Enter()
    {
        rayOffset.y = 1;
        maxDistance = 10;
    }

    public void Execute(Vector3 pos)
    {
        Physics.Raycast(pos + rayOffset, Vector3.forward * maxDistance, out var hit);
        
        if (!hit.collider.CompareTag("Player") || hit.collider == null) return;

        stimuli = true;
    }

    public void Exit()
    {
        
    }
}
