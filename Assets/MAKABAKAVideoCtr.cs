using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;


public class MAKABAKAVideoCtr : MonoBehaviour
{
    VideoPlayer videoPlayer;
    CanvasGroup canvasGroup;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        canvasGroup = transform.GetChild(0).GetComponent<CanvasGroup>();
    }





    void Update()
    {
        
    }
}
