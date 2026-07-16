using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    private EnemyController currentEnemy;
    private GameObject[] enemies;

    private void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("enemy");
    }

    public void CaughtPlayer()
    {
        foreach (var enemy in enemies)
        {
            enemy.GetComponent<EnemyController>().movementSM.SwitchStates(enemy.GetComponent<EnemyController>().movementSM.patrolState, enemy.GetComponent<NavMeshAgent>());
        }
    }
}
