using System.Collections;
using UnityEngine;

public class FootstepSoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource feet;
    private EnemyController ec;
    private bool timerToggle;

    public float soundTimer;
    private float stepOffset;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ec = gameObject.GetComponent<EnemyController>();
        timerToggle = true;
        stepOffset = Random.Range(0.1f, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!timerToggle) return;

        StartCoroutine(FootstepSoundTimer());
    }

    private IEnumerator FootstepSoundTimer()
    {
        timerToggle = false;
        yield return new WaitForSeconds(soundTimer + stepOffset);
        feet.Play();
        timerToggle = true;
    }
}
