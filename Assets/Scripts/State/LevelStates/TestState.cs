using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestState<T> : IState
{
    T actor;
    public void StateEnter(object _actor)
    {
        actor = _actor;
    }

    public void StateStay()
    {
    }

    public void StateExit()
    {
    }



    public void StateEnter()
    {
        throw new System.NotImplementedException();
    }
}
