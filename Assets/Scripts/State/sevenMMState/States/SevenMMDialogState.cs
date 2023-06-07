using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SevenMMDialogState : IState
{
    string dialogID;
    
    public SevenMMDialogState(string _dialogID)
    {
        dialogID = _dialogID;
    }
    
    
    SevenMMActor actor;
    DialogDataDetail dialogDataDetail;

    float timer;
    int dialogIndex;
    public void StateEnter(object _actor)
    {
        actor  = (SevenMMActor)_actor;

        dialogDataDetail = DialogSystem.instance.GetDialogDataDetail(dialogID);
        dialogIndex = 0;
        timer = 3;

    }

    
    public void StateStay()
    {
        timer += Time.deltaTime;

        if(timer > 3 && dialogIndex < dialogDataDetail.sentences.Count)
        {
            DialogSystem.instance.SetDialogText(dialogDataDetail.sentences[dialogIndex]);
            dialogIndex++;
        }
        else
        {
            actor.ChangeState(new SevenMMIdleState());
        }
    }

    public void StateExit()
    {
    }
}
