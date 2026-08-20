using UnityEngine;

public class OpeningDoors : MonoBehaviour
{
    public int doorNum;
    [SerializeField] private Animator anim;
    [SerializeField] private AudioSource audio;

    private bool doorState;
    
    public void OpenDoor()
    {
        doorState = true;
        if(doorState != anim.GetBool("open"))
            audio.Play();
        
        anim.SetBool("open", doorState);
    }

    public void CloseDoor()
    {
        doorState = false;
        if(doorState != anim.GetBool("open"))
            audio.Play();
        
        anim.SetBool("open", doorState);
    }
}
