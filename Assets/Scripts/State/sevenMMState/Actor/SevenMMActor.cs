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


    public void CallLevelSystemSetNextState(IState nextState)
    {
        LevelSystem.instance.ChangeState(nextState);
    }

    public DialogDataDetail GetDialogDataDetail(string dialogID)
    {
        return DialogSystem.instance.GetDialogDataDetail(dialogID);
    }

    public float GetDialogGapTimer()
    {
        return DialogSystem.instance.GetGapTimer();
    }

    public void SetDialogText(string text)
    {
        DialogSystem.instance.SetDialogText(text);
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
