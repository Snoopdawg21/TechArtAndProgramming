using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject tutorialScreen;
    private bool screenToggle;
    [SerializeField] private GameObject pauseScreen;
    private bool pauseToggle;

    private GameStateManager gsm;
    public KeySpawning spawn;

    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0) return;
        
        spawn = gameObject.GetComponent<KeySpawning>();
        
        gsm = new GameStateManager(this);
        gsm.SwitchStates(gsm.playingState);
    }
    
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void WinGame()
    {
        gsm.SwitchStates(gsm.winState);
    }

    public void PauseGame()
    {
        pauseToggle = !pauseToggle;
        pauseScreen.gameObject.SetActive(pauseToggle);

        switch (pauseToggle)
        {
            case true:
                gsm.SwitchStates(gsm.winState);
                break;
            case false:
                gsm.SwitchStates(gsm.playingState);
                break;
        }
    }

    public void HowToButton()
    {
        screenToggle = !screenToggle;
        tutorialScreen.SetActive(screenToggle);
    }
}
