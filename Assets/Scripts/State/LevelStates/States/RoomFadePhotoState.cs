using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomFadePhotoState : IState
{
    LevelSystem actor;
    public void StateEnter(object _actor)
    {
        actor = (LevelSystem)_actor;

        actor.ShowFadePhoto();

    }

    public void StateStay()
    {

    }

    public void StateExit()
    {
        
    }



}
