using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    IState currentState;
    

   
    void Start()
    {
        currentState = new TestState();
        currentState.StateEnter(this);
    }

    void Update()
    {
        currentState.StateStay();
    }

    public void ChangeState(IState newState)
    {
        currentState.StateExit();
        currentState = newState;
        currentState.StateEnter(this);
    }
}
