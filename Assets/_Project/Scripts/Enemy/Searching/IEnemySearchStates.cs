using UnityEngine;

public interface IEnemySearchStates
{
    bool stimuli { get; set; }
    void Enter();
    void Execute(Vector3 pos);
    void Exit();
}
