using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UserLookPhotoCtr : MonoBehaviour
{
    public static UserLookPhotoCtr instance;

    private void Awake() {
        instance = this;
    }

    public void ShowUserLookPhoto()
    {
        // DOTween.To(() => tra , x => canvasGroup.alpha = x , 1 ,1)
        //     .SetEase(Ease.Linear);
        transform.DOMoveY(1, 1).onComplete += delegate{
            RoomSceneCameraCtr.instance.StartRayDeceted();
        };
    }
}
