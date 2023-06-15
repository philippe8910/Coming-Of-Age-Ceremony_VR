using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomFadeToTempleState : IState
{
    LevelSystem actor;
    public void StateEnter(object _actor)
    {
        actor = (LevelSystem)_actor;
        actor.StartFadeToTemple();
    }

    public void StateStay()
    {

    }

    public void StateExit()
    {
        
    }



}
