using UnityEngine;
using UnityEngine.InputSystem;

public class StartMovement : MonoBehaviour
{
    private PlayerMovementStateMachine movementSM;
    
    // public void OnHorizontal(InputValue value)
    // {
    //     if (value.Get<float>() == 0) return;
    //     
    //     movementSM.SwitchStates(movementSM.aliveState);
    // }
    //
    // public void OnHorizontal(InputValue value)
    // {
    //     if (value.Get<float>() == 0) return;
    //     
    //     movementSM.SwitchStates(movementSM.aliveState);
    // }
}
