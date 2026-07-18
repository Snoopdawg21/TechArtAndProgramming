using UnityEngine;

public class KeySpawning : MonoBehaviour
{
    [SerializeField] private GameObject keyPrefab;
    
    private GameObject[] spawnPoints;
    private GameObject[] keys;

    private int previousSpawnPos;
    private int spawnPos;
    
    void Awake()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        keys = new GameObject[3];
        keys[0] = GameObject.FindGameObjectWithTag("Key");
    }

    public void ScatterKeys()
    {
        for (var i = 1; i < keys.Length; i++)
        {
            while (spawnPos == previousSpawnPos)
            {
                spawnPos = Random.Range(0, spawnPoints.Length);
            }
            
            keys[i] = Instantiate(keyPrefab, spawnPoints[spawnPos].transform);
            keys[i].GetComponent<CollectingKeys>().keyNum = i;
            previousSpawnPos = spawnPos;
        }
    }
}
