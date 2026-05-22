using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private int gridSize;
    
    [Space(10)]
    [Header("Hallway Information")]
    [SerializeField] private Vector3Int[] hallWorldPositions;
    [SerializeField] private Vector2Int[] hallGridPositions;
    
    [Space(10)]
    [Header("Room Information")]
    [SerializeField] private Vector3Int[] roomWorldPositions;
    [SerializeField] private Vector2Int[] roomGridPositions;
    [SerializeField] private int numberOfRooms;

    [Space(10)] 
    [Header("Prefabs")]
    [SerializeField] private GameObject hallwayPrefab;

    [SerializeField] private GameObject cornerPrefab;
    
    void Start()
    {
        GenerateRooms();
    }

    
    void Update()
    {
        
    }

    private void GenerateRooms()
    {
        numberOfRooms = Random.Range(3, 10);
        roomWorldPositions = new Vector3Int[numberOfRooms];
        roomGridPositions = new Vector2Int[numberOfRooms];

        for (int i = 0; i < numberOfRooms; i++)
        {
            roomGridPositions[i].x = Random.Range(0, gridSize);
            roomGridPositions[i].y = Random.Range(0, gridSize);

            roomWorldPositions[i].x = roomGridPositions[i].x * 4;
            roomWorldPositions[i].z = roomGridPositions[i].y * 4;
            
            Instantiate(hallwayPrefab, roomWorldPositions[i], Quaternion.identity);
        }
        
        FindCorners();
    }

    private void FindCorners()
    {
        hallGridPositions = new Vector2Int[numberOfRooms];
        hallWorldPositions = new Vector3Int[numberOfRooms];
        
        for (int i = 0; i < numberOfRooms - 1; i++)
        {
            hallGridPositions[i] = new Vector2Int(roomGridPositions[i].x, roomGridPositions[i+1].y);
            hallWorldPositions[i] = new Vector3Int(hallGridPositions[i].x * 4, 0, hallGridPositions[i].y * 4);
            
            Instantiate(cornerPrefab, hallWorldPositions[i], Quaternion.identity);
        }
    }
}
