using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    private Vector3 spawnPoint;

    private void Start()
    {
        spawnPoint = transform.position;
    }
    
    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("hi");
        if (!col.gameObject.CompareTag("enemy")) return;
        
        Debug.Log("touched");
        transform.position = spawnPoint;
    }
}
