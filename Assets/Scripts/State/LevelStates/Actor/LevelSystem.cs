using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatesPool
{
    RoomStartState,
}

public class LevelSystem : MonoBehaviour
{
    public static LevelSystem instance;
    private void Awake() {
        instance = this;
    }



    IState currentState;
    

   [SerializeField] StatesPool defultState;
    void Start()
    {
        currentState = SetDefultState(defultState);
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

    private IState SetDefultState(StatesPool _defultState)
    {
        switch(_defultState)
        {
            case StatesPool.RoomStartState:
                return new RoomStartState();
            default:
                return null;
        }
    }

    public void CallSevenMMActorTalk(string dialogID, IState NextState)
    {
        SevenMMActor.instance.ChangeState(new SevenMMDialogState(dialogID, NextState));
    }

    public void CallMAKABAKAVideoCtrPlayVideo()
    {
        MAKABAKAVideoCtr.instance.StartPlayVideo();
    }

    public void ShowFadePhoto()
    {
        UserLookPhotoCtr.instance.ShowUserLookPhoto();
    }

    public void StartFadeToTemple()
    {
        RoomBlackHoleCtr.instance.StartFadeToTemple();
    }
}
