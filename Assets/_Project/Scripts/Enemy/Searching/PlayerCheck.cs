using UnityEngine;

public class PlayerCheck
{
    private Vector3 rayOffset;
    private float radius;
    private LayerMask playerLayer;

    public PlayerCheck(EnemyController enemy)
    {
        rayOffset = enemy.rayOffset;
        radius = enemy.radius;
        playerLayer = LayerMask.NameToLayer("Player");
    }

    public bool VisualCheck(Transform pos)
    {
        Physics.SphereCast(pos.position + rayOffset, radius, pos.forward, out var hit, Mathf.Infinity);

        Debug.Log(hit.collider?.gameObject.name);
        return hit.collider?.gameObject.layer == playerLayer;
    }
}
