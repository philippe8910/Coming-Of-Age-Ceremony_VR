public interface IState
{
    void StateEnter(object _actor);

    void StateStay();

    void StateExit();
} 
