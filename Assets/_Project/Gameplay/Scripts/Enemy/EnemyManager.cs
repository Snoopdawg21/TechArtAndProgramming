using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    private EnemyController currentEnemy;
    private GameObject[] enemies;

    public GameManager gm { get; private set; }

    private void Start()
    {
        gm = gameObject.GetComponent<GameManager>();
        
        enemies = GameObject.FindGameObjectsWithTag("enemy");
        Debug.Log(enemies.Length);
    }

    public void CaughtPlayer()
    {
        foreach (var enemy in enemies)
        {
            currentEnemy = enemy.GetComponent<EnemyController>();
            
            currentEnemy.movementSM.SwitchStates(currentEnemy.movementSM.patrolState, enemy.GetComponent<NavMeshAgent>());
        }
        
        gm.uiManager.HideText();
    }
}
