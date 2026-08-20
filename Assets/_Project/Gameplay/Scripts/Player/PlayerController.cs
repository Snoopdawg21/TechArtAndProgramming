using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool[] numOfKeys;
    
    public PlayerMovementStateMachine movementSM;
    private Vector3 spawnPos;

    public bool isAlive = true;
    
    public MovementCalculation calc;

    public GameManager gm { get; private set; }

    [SerializeField] private AudioSource keyAudio;
    
    private void Start()
    {
        calc = GetComponent<MovementCalculation>();
        movementSM = new PlayerMovementStateMachine(this);
        movementSM.SwitchStates(movementSM.aliveState);

        numOfKeys = new bool[GameObject.FindGameObjectsWithTag("Key").Length];
        
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        
        spawnPos = transform.position;
        spawnPos.y -= 1;
    }

    private void FixedUpdate()
    {
        movementSM.currentState?.Execute();
    }

    public void HitEnemy()
    {
        if (!isAlive) return;
        isAlive = false;
        
        transform.position = spawnPos;
        movementSM.SwitchStates(movementSM.deadState);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CollectingKeys>())
        {
            numOfKeys[other.GetComponent<CollectingKeys>().keyNum] = true;
            gm.uiManager.GotKey();
            keyAudio.Play();
            Destroy(other.gameObject);
            return;
        }

        if (other.GetComponent<OpeningDoors>())
        {
            if (!numOfKeys[other.GetComponent<OpeningDoors>().doorNum])
            {
                gm.uiManager.FailedDoor();
                return;
            }
            
            other.GetComponent<OpeningDoors>().OpenDoor();
        }
    }
}
