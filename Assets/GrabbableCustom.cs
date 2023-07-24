using System;
using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

public class GrabbableCustom : MonoBehaviour
{
    public bool isGrab;

    public string answerTag;

    public UnityEvent OnGrab, OnRelease;
    
    private void Start()
    {
        var eventWrapper = GetComponent<PointableUnityEventWrapper>();

        eventWrapper.WhenSelect.AddListener(delegate
        {
            isGrab = true;
            OnGrab.Invoke();
        });

        eventWrapper.WhenUnselect.AddListener(delegate
        {
            isGrab = false;
            OnRelease.Invoke();
        });
    }

    [Button]
    public void ClickOnGrab()
    {
        OnGrab.Invoke();
    }
}
