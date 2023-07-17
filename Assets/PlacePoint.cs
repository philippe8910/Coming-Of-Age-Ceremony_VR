using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlacePoint : MonoBehaviour
{
    public GrabbableCustom currentGrabbable;

    public string answerTag;

    public UnityEvent OnCurrentAnswer;

    public bool isEnter , isPass;
    // Update is called once per frame
    void Update()
    {
        if (isEnter && currentGrabbable?.isGrab == false && currentGrabbable.answerTag == answerTag)
        {
            OnCurrentAnswer?.Invoke();
            isPass = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Grabbable")
        {
            isEnter = true;
            currentGrabbable = other.GetComponent<GrabbableCustom>();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Grabbable")
        {
            isEnter = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Grabbable")
        {
            isEnter = false;
            //currentGrabbable = null;
        }
    }
}
