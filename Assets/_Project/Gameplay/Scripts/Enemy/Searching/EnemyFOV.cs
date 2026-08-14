using System.Diagnostics;
using UnityEngine;
using UnityEditor;
using Debug = UnityEngine.Debug;

public class EnemyFOV : MonoBehaviour
{
    [SerializeField] private float distanceFOV;
    [SerializeField, Range(0, 360)] private float range;
    [SerializeField] private float seeDistance;
    [SerializeField] private Transform eyes;
    
    private Collider[] inFOV;
    private float signedAngle;
    
    public bool seesPlayer {get; private set;}
    public Transform playerPos { get; private set; }

    private void Update()
    {
        seesPlayer = false;
        
        inFOV = Physics.OverlapSphere(transform.position, distanceFOV);
        foreach (var col in inFOV)
        {
            if (!col.CompareTag("Player")) continue;

            if (Mathf.Abs(Vector3.Distance(transform.position, col.transform.position)) <= seeDistance)
            {
                ShootRay(col);
                return;
            }
            
            signedAngle = Vector3.Angle(transform.forward, col.transform.position - transform.position);

            if (Mathf.Abs(signedAngle) >= range / 2) return;

            ShootRay(col);
        }
    }
    
    private void ShootRay(Collider col) 
    {
        Physics.Raycast(eyes.position, col.transform.position - transform.position, out RaycastHit hit, Mathf.Infinity);
        DevLogger.Log(hit.collider.name);
        Debug.DrawRay(eyes.position, col.transform.position - transform.position, Color.red);
        if (hit.collider.GetComponent<PlayerController>())
            FoundPlayer(hit.collider.transform);
    }


    private void FoundPlayer(Transform playerTrans)
    {
        seesPlayer = true;
        playerPos = playerTrans;
    }
    
    private void OnDrawGizmos()
    {
        Handles.color = new Color(0, 1, 0, 0.4f);
        
        Handles.DrawSolidDisc(
            transform.position, 
            Vector3.up, 
            seeDistance
            );
        
        Handles.DrawSolidArc(
            transform.position, 
            transform.up, 
            Quaternion.AngleAxis(-range / 2, transform.up) * transform.forward, 
            range, 
            distanceFOV
            );
    }
}
