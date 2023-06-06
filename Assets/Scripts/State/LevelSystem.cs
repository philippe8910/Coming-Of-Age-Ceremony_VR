using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatesPool
{
    ChoeseGenderState,
}

public class LevelSystem : MonoBehaviour
{
    [SerializeField] StatesPool defultState;
    IState currentState;
    

   
    void Start()
    {
        currentState = SetDefultState(defultState);
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

    private IState SetDefultState(StatesPool _defultState)
    {
        switch(_defultState)
        {
            case StatesPool.ChoeseGenderState:
                return new ChoeseGenderState();
            default:
                return null;
        }
    }
}
