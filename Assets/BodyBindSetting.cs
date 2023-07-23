using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyBindSetting : MonoBehaviour
{
    public Transform bodyRotation, bodPosition;

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x , bodyRotation.rotation.eulerAngles.y , transform.rotation.eulerAngles.z);
        transform.position = new Vector3(bodPosition.position.x, transform.position.y ,bodPosition.position.z);
    }
}
