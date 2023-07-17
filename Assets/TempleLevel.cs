using System.Collections;
using System.Collections.Generic;
using Events;
using Project;
using UnityEngine;

public class TempleLevel : MonoBehaviour
{
    public List<PlacePoint> currentPassObjects = new List<PlacePoint>();

    public List<GameObject> placeObjectPack = new List<GameObject>();

    void Start()
    {
        EventBus.Post(new TempleLevelStartDetected());
        
        EventBus.Subscribe<StartPlaceObjectLevelDetected>(OnStartPlaceObjectLevelDetected);
        EventBus.Subscribe<PassPlacePointLevelDetected>(OnPassPlacePointLevelDetected);
    }

    private void OnPassPlacePointLevelDetected(PassPlacePointLevelDetected obj)
    {
        
    }

    private void OnStartPlaceObjectLevelDetected(StartPlaceObjectLevelDetected obj)
    {
        placeObjectPack.ForEach(delegate(GameObject o)
        {
            o.SetActive(true);
        });
    }
}
