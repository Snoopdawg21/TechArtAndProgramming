using UnityEngine;

public class OpeningDoors : MonoBehaviour
{
    public int doorNum;
    [SerializeField] private Animator anim;
    
    public void OpenDoor()
    {
        anim.SetBool("open", true);
    }

    public void CloseDoor()
    {
        anim.SetBool("open", false);
    }
}
