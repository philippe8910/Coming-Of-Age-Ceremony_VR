using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SevenMMActor : MonoBehaviour
{
    // [SerializeField] StatesPool defultState;
    public static SevenMMActor instance;
    IState currentState;
    void Awake()
    {
        instance = this;
        // currentState = SetDefultState(defultState);
        currentState = new SevenMMIdleState();
        currentState.StateEnter(this);
    }

    void Update()
    {
        currentState.StateStay();
    }

    public void ListenState(bool isEnter, IState newState)
    {
        if(isEnter) ChangeState(newState);
    }

    public void ChangeState(IState newState)
    {
        currentState.StateExit();
        currentState = newState;
        currentState.StateEnter(this);
    }

    // private IState SetDefultState(StatesPool _defultState)
    // {
    //     switch(_defultState)
    //     {
    //         case StatesPool.ChoeseGenderState:
    //             return new ChoeseGenderState();
    //         default:
    //             return null;
    //     }
    // }
}
