using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UXArrowCtr : MonoBehaviour
{
    GameObject hintTarget;

    void Start()
    {
        
    }

    void Update()
    {
        transform.forward = (hintTarget.transform.position - transform.position).normalized;
    }
    public void SetHintGameObject(GameObject _hintTarget)
    {
        hintTarget = _hintTarget;
        transform.GetChild(0).gameObject.SetActive(true);
    }

    public void SetArrowActiveFalse()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
