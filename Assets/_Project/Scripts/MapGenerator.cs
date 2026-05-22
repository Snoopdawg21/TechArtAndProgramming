using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private int gridSize;
    
    [Space(10)]
    [Header("Hallway Information")]
    [SerializeField] private Vector3Int[] hallWorldPositions;
    [SerializeField] private int[,] hallGridPositions;
    
    [Space(10)]
    [Header("Room Information")]
    [SerializeField] private Vector3Int[] roomWorldPositions;
    [SerializeField] private int[,] roomGridPositions;
    [SerializeField] private int numberOfRooms;
    
    void Start()
    {
        GenerateHallways();
    }

    
    void Update()
    {
        
    }

    private void GenerateHallways()
    {
        numberOfRooms = Random.Range(3, 10);
        roomWorldPositions = new Vector3Int[numberOfRooms];
        roomGridPositions = new int[numberOfRooms, numberOfRooms];

        for (int i = 0; i < numberOfRooms; i++)
        {
            roomGridPositions[i , i] = Random.Range(0, gridSize);
            Debug.Log(roomGridPositions[i , i]);
        }
    }
}
