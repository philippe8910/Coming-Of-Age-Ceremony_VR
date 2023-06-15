using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomStartState : IState
{
    LevelSystem actor;
    public void StateEnter(object _actor)
    {
        actor = (LevelSystem)_actor;

        actor.CallSevenMMActorTalk("1-1", new RoomPlayVideoState());
    }

    public void StateStay()
    {

    }

    public void StateExit()
    {
        
    }



}
