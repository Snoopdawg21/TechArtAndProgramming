using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameStateManager gsm;

    public KeySpawning spawn;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawn = gameObject.GetComponent<KeySpawning>();
        
        gsm = new GameStateManager(this);
        gsm.SwitchStates(gsm.playingState);
    }
    
    public void WinGame()
    {
        gsm.SwitchStates(gsm.winState);
    }
}
