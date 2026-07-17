using UnityEngine;

public class WinGame : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if (!col.GetComponent<PlayerController>()) return;
        
        Debug.Log("You win!");
        Time.timeScale = 0;
    }
}
