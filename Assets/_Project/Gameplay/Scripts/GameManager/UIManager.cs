using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject winScreen;

    public void Win()
    {
        winScreen.SetActive(true);
    }
}
