using UnityEngine;
using UnityEditor;

public class EnemyFOV : MonoBehaviour
{
    [SerializeField] private float circularFOV;
    [SerializeField] private float distanceFOV;
    [SerializeField, Range(0, 360)] private float range;

    private Collider[] nearEnemy;
    private Collider[] inFOV;
    private float signedAngle;
    
    public bool seesPlayer {get; private set;}
    public Transform playerPos { get; private set; }

    private void Update()
    {
        seesPlayer = false;
        nearEnemy = Physics.OverlapSphere(transform.position, circularFOV);

        foreach (var col in nearEnemy)
        {
            if (!col.CompareTag("Player")) continue;

            seesPlayer = true;
            playerPos = col.transform;
            return;
        }
        
        inFOV = Physics.OverlapSphere(transform.position, distanceFOV);
        foreach (var col in inFOV)
        {
            if (!col.CompareTag("Player")) continue;
            
            signedAngle = Vector3.Angle(transform.forward, col.transform.position - transform.position);
            
            if(Mathf.Abs(signedAngle) < range / 2)
            {
                seesPlayer = true;
                playerPos = col.transform;
            }
            
            break;
        }
    }

    private void OnDrawGizmos()
    {
        Handles.color = new Color(0, 1, 0, 0.4f);
        
        Handles.DrawSolidDisc(
            transform.position, 
            Vector3.up, 
            circularFOV
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
