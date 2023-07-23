using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererScript : MonoBehaviour
{
    private LineRenderer lineRenderer;
    public Transform firstPos, endPos;
    public Vector3 target;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0 , firstPos.position);
        lineRenderer.SetPosition(1 , firstPos.position + firstPos.forward * 20);
    }

    public void SetTarget(Vector3 _target)
    {
        target = _target;
    }
}
