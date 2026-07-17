using UnityEngine;

public class WinGame : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if (!col.GetComponent<PlayerController>()) return;
        
        col.GetComponent<PlayerController>().gm.WinGame();
    }
}
