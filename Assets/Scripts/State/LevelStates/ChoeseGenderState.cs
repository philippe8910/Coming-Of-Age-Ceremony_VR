using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoeseGenderState : IState
{
    LevelSystem system;

    public void StateEnter(LevelSystem _system)
    {
        system  = _system;
    }

    public void StateStay()
    {
    }

    public void StateExit()
    {
    }
}
