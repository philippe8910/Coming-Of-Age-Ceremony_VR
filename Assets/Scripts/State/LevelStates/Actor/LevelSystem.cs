using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatesPool
{
    ChoeseGenderState,
}

public class LevelSystem : MonoBehaviour
{
    public static LevelSystem instance;
    private void Awake() {
        instance = this;
    }



    IState currentState;
    

   
    void Start()
    {
        //currentState = SetDefultState(defultState);
        // currentState = new 
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
