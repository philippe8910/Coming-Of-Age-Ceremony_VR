using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SevenMMIdleState : IState
{
    
    SevenMMActor actor;
    public void StateEnter(object _actor)
    {
        actor  = (SevenMMActor)_actor;
    }

    public void StateStay()
    {
    }

    public void StateExit()
    {
    }
}
