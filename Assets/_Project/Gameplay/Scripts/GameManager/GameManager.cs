using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject tutorialScreen;
    private bool screenToggle;
    [SerializeField] private GameObject pauseScreen;
    private bool pauseToggle;

    public bool gameOver;

    private GameStateManager gsm;
    public KeySpawning spawn { get; private set; }

    public PlayerController playerControl;
    public UIManager uiManager;

    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0) return;
        
        spawn = gameObject.GetComponent<KeySpawning>();
        uiManager = gameObject.GetComponent<UIManager>();
        
        playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        
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
        if (gameOver) return;
        
        pauseToggle = !pauseToggle;
        pauseScreen.gameObject.SetActive(pauseToggle);

        switch (pauseToggle)
        {
            case true:
                gsm.SwitchStates(gsm.pauseState);
                Cursor.lockState = CursorLockMode.None;
                break;
            case false:
                gsm.SwitchStates(gsm.playingState);
                Cursor.lockState = CursorLockMode.Locked;
                break;
        }
    }

    public void HowToButton()
    {
        screenToggle = !screenToggle;
        tutorialScreen.SetActive(screenToggle);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
