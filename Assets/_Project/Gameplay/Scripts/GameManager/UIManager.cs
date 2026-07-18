using System.Collections;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject winScreen;
    [SerializeField] private TextMeshProUGUI informationText;
    [SerializeField] private float timer;
    
    public void FailedDoor()
    {
        informationText.text = "You don't have the Key for that Door!";
        StartCoroutine(textTimer());
    }
    
    public void GotKey()
    {
        informationText.text = "Picked Up a Key!";
        StartCoroutine(textTimer());
    }
    
    public void GotSeen()
    {
        informationText.text = "Someone Saw You!";
        StartCoroutine(textTimer());
    }

    public void HideText()
    {
        informationText.text = "";
    }
    
    public void Win()
    {
        winScreen.SetActive(true);
    }

    private IEnumerator textTimer()
    {
        yield return new WaitForSeconds(timer);
        HideText();
    }
}
