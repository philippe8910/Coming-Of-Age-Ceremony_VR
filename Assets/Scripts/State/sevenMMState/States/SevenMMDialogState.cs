using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SevenMMDialogState : IState
{
    string dialogID;
    IState levelNextState;
    
    public SevenMMDialogState(string _dialogID, IState _levelNextState)
    {
        dialogID = _dialogID;
        levelNextState = _levelNextState;
    }
    
    
    SevenMMActor actor;
    DialogDataDetail dialogDataDetail;

    float gapTimer;
    float timer;
    int dialogIndex;
    public void StateEnter(object _actor)
    {
        actor  = (SevenMMActor)_actor;

        dialogDataDetail = actor.GetDialogDataDetail(dialogID);
        gapTimer = actor.GetDialogGapTimer();
        dialogIndex = 0;
        timer = gapTimer;

        actor.SetDialogText(dialogDataDetail.sentences[dialogIndex]);
    }

    
    public void StateStay()
    {
        timer += Time.deltaTime;

        if(timer > gapTimer && dialogIndex < dialogDataDetail.sentences.Count)
        {
            actor.SetDialogText(dialogDataDetail.sentences[dialogIndex]);
            
            dialogIndex++;
            timer = 0;
        }
        else if(timer > gapTimer && dialogIndex >= dialogDataDetail.sentences.Count)
        {
            actor.ChangeState(new SevenMMIdleState());
        }
    }

    public void StateExit()
    {
        actor.CallLevelSystemSetNextState(levelNextState);
    }
}
