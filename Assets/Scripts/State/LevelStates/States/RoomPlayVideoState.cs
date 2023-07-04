using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomPlayVideoState : IState
{
    LevelSystem actor;
    public void StateEnter(object _actor)
    {
        actor = (LevelSystem)_actor;
    }

    public void StateStay()
    {

    }

    public void StateExit()
    {
        
    }



}
