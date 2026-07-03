using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    private Vector3 spawnPoint;

    private void Start()
    {
        spawnPoint = transform.position;
    }
    
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("enemy")) return;
        
        Debug.Log("touched");
        transform.position = spawnPoint;
    }
}
