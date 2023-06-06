public interface IState
{
    void StateEnter(LevelSystem _system);

    void StateStay();

    void StateExit();
} 
