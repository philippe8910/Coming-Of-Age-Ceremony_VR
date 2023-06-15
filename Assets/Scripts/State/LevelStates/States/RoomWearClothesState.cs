using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomWearClothesState : IState
{
    LevelSystem actor;
    public void StateEnter(object _actor)
    {
        actor = (LevelSystem)_actor;

        //呼叫衣櫃打開之類的
        //穿完衣服回呼(RoomFadePhotoState)叫明信片(轉場照片)飛出
        //測試先跳過
        actor.ChangeState(new RoomFadePhotoState());
    }

    public void StateStay()
    {

    }

    public void StateExit()
    {
        
    }



}
