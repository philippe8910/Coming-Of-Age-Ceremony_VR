using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using DG.Tweening;
using Sirenix.OdinInspector;

public class MAKABAKAVideoCtr : MonoBehaviour
{
    public static MAKABAKAVideoCtr instance;
    private void Awake() {
        instance = this;
    }

    VideoPlayer videoPlayer;
    CanvasGroup canvasGroup;

    bool isFirstEnd;
    void Start()
    {
        isFirstEnd = false;
        videoPlayer = GetComponent<VideoPlayer>();
        canvasGroup = transform.GetChild(0).GetComponent<CanvasGroup>();

        videoPlayer.loopPointReached += VideoEnd;

        // DOTween.To(() => 0 , x => canvasGroup.alpha = x , 1 ,0.1f)
        //     .SetEase(Ease.Linear).onComplete += delegate{
                
        // };
    }


    [Button]
    public void StartPlayVideo()
    {        
        DOTween.To(() => canvasGroup.alpha , x => canvasGroup.alpha = x , 1 ,1)
            .SetEase(Ease.Linear);

        videoPlayer.Stop();
        videoPlayer.Play();
    }

    

    private void VideoEnd(VideoPlayer videoPlayer)
    {
        // videoPlayer.Stop();
        // DOTween.To(() => canvasGroup.alpha , x => canvasGroup.alpha = x , 0 ,1)
        //     .SetEase(Ease.Linear);

        if(!isFirstEnd)
        {
            isFirstEnd = true;
            //UserLookPhotoCtr.instance.ShowUserLookPhoto();
            LevelSystem.instance.ChangeState(new RoomWearClothesState());
        }
    }







    void Update()
    {
        
    }
}
