public interface IGameStates
{
    void Enter(GameManager manager);
    void Execute();
    void Exit();
}
