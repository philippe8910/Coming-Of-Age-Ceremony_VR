using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Events;
using Project;
using UnityEngine;

public class ScenesChangeEffect : MonoBehaviour
{
    public float speed = 2;
    
    public void Start()
    {
        var canvasGroup = GetComponent<CanvasGroup>();
        
        DOTween.To(() => canvasGroup.alpha, x => canvasGroup.alpha = x, 0, speed).onComplete += delegate
        {
            //一開始全亮
        };
        
        EventBus.Subscribe<ChangeScenesEffectDetected>(OnChangeScenesEffectDetected);
        EventBus.Subscribe<TeleportEffectDetected>(OnTeleportEffectDetected);
    }

    private void OnTeleportEffectDetected(TeleportEffectDetected obj)
    {
        var canvasGroup = GetComponent<CanvasGroup>();
        
        DOTween.To(() => canvasGroup.alpha, x => canvasGroup.alpha = x, 1, 0.2f).onComplete += delegate
        {
            //全暗
            obj.events?.Invoke();
            
            DOTween.To(() => canvasGroup.alpha, x => canvasGroup.alpha = x, 0, 0.2f).onComplete += delegate
            {
                //全亮
                DOTween.KillAll();
            };
        };
    }

    private void OnChangeScenesEffectDetected(ChangeScenesEffectDetected obj)
    {
        var canvasGroup = GetComponent<CanvasGroup>();
        
        DOTween.To(() => canvasGroup.alpha, x => canvasGroup.alpha = x, 1, speed).onComplete += delegate
        {
            //全暗
            obj.events?.Invoke();
            
            DOTween.To(() => canvasGroup.alpha, x => canvasGroup.alpha = x, 0, speed).onComplete += delegate
            {
                //全亮
            };
        };
    }
}
