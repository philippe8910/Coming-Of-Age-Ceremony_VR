using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Events;
using Events._7MMEvent;
using Project;
using UnityEngine;

public class TempleLevel : MonoBehaviour
{
    public List<PlacePoint> currentPassObjects = new List<PlacePoint>();

    public List<GameObject> placeObjectPack = new List<GameObject>();

    public List<GameObject> teleportPoints = new List<GameObject>();

    public int loopCount = 0;

    async void Start()
    {
        await Task.Delay(100);

        EventBus.Post(new DialogDetected("2-1", delegate{
            EventBus.Post(new TempleLevelStartDetected());
            EventBus.Post(new StartPlaceObjectLevelDetected());
        }));
        
        placeObjectPack.ForEach(delegate(GameObject o)
        {
            o.SetActive(false);
        });
        
        EventBus.Subscribe<StartPlaceObjectLevelDetected>(OnStartPlaceObjectLevelDetected);
        EventBus.Subscribe<PassPlacePointLevelDetected>(OnPassPlacePointLevelDetected);
        EventBus.Subscribe<PassLoopRoundDetected>(OnPassLoopRoundDetected);
    }
    

    private void OnPassLoopRoundDetected(PassLoopRoundDetected obj)
    {
        ///繞完轎
        EventBus.Post(new DialogDetected("2-3", null));
    }


    private void OnPassPlacePointLevelDetected(PassPlacePointLevelDetected obj)
    {
        ///抓取物件完成
        
        EventBus.Post(new DialogDetected("2-2", null));

        teleportPoints.ForEach(delegate(GameObject o)
        {
            o.SetActive(true);
        });


    }

    private void OnStartPlaceObjectLevelDetected(StartPlaceObjectLevelDetected obj)
    {
        ///開始抓取物件關卡監聽
        
        placeObjectPack.ForEach(delegate(GameObject o)
        {
            o.SetActive(true);
        });

        StartCoroutine(StartDetected());

        IEnumerator StartDetected()
        {
            bool allPass = true;
            
            currentPassObjects.ForEach(delegate(PlacePoint point)
            {
                if (!point.isPass)
                {
                    allPass = false;
                }
            });

            if (allPass)
            {
                EventBus.Post(new PassPlacePointLevelDetected());
            }
            else
            {
                yield return new WaitForSeconds(0.1f);
                StartCoroutine(StartDetected());
            }
        }
    }

    public void RoundLoop()
    {
        ///繞完一圈
        loopCount++;

        if (loopCount >= 3)
        {
            EventBus.Post(new PassLoopRoundDetected());
        }
    }
}
