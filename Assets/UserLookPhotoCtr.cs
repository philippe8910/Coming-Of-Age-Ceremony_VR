using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Events;
using Project;
using System.Threading.Tasks;

public class UserLookPhotoCtr : MonoBehaviour
{
    public static UserLookPhotoCtr instance;

    private void Awake() {
        instance = this;
    }

    private void Start()
    {
        //ShowUserLookPhoto();
    }

    public async void ShowUserLookPhoto()
    {

        await Task.Delay(5000);

        print("ShowUserLookPhoto");

        // DOTween.To(() => tra , x => canvasGroup.alpha = x , 1 ,1)
        //     .SetEase(Ease.Linear);
        transform.DOMoveY(1, 1).onComplete += delegate{
            RoomSceneCameraCtr.instance.StartRayDeceted();
            //EventBus.Post(new SwitchSceneToTempleDetected());
        };
    }
}
