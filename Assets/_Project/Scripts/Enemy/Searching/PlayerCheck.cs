using UnityEngine;

public class PlayerCheck
{
    public bool stimuli { get; private set; }
    
    private Vector3 rayOffset;
    private float maxDistance;
    private float stimuliTime;

    public PlayerCheck(EnemyController enemy)
    {
        rayOffset.y = 1;
        maxDistance = 10;
    }

    public bool VisualCheck(Vector3 pos)
    {
        Physics.Raycast(pos + rayOffset, Vector3.forward * maxDistance, out var hit);
        
        if (!hit.collider.CompareTag("Player") || hit.collider == null) return false;
        Debug.Log(hit.collider.name);
        return true;
    }
}
