using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.XR;

public class TeleportEvent : MonoBehaviour
{
    public UnityEvent OnTeleportEnd;

    public Image loadBar;

    public bool isTrigger;

    public Transform player;
    
    public InputDevice rightController;
    private bool isVibrating = false;

    private void Start()
    {
        player = FindObjectOfType<OVRCameraRig>().transform;
        
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithRole(InputDeviceRole.RightHanded, devices);
        rightController = devices.FirstOrDefault();
    }

    private void Update()
    {
        var canvas = loadBar.transform.parent;
        var target = new Vector3(0, canvas.transform.position.y, canvas.transform.localPosition.z);

        
        canvas.transform.LookAt(target);
        
        
        if (isTrigger)
        {
            loadBar.fillAmount += Time.deltaTime * 2;
        }
        else
        {
            loadBar.fillAmount -= Time.deltaTime * 2;
        }

        isTrigger = false;
    }


    [Button]
    public void TeleportEnd()
    {
        transform.gameObject.SetActive(false);
        OnTeleportEnd?.Invoke();
    }
    
    private void StartVibration(float duration, float amplitude)
    {
        if (rightController != null && !isVibrating)
        {
            // 設置震動參數
            HapticCapabilities capabilities;
            if (rightController.TryGetHapticCapabilities(out capabilities))
            {
                if (capabilities.supportsImpulse)
                {
                    isVibrating = true;

                    // 設置震動的持續時間和振幅
                    float startTime = Time.time;
                    float endTime = startTime + duration;

                    // 震動迴圈
                    while (Time.time < endTime)
                    {
                        rightController.SendHapticImpulse(0, amplitude);

                        // 控制震動的頻率
                        float interval = 0.01f;
                        float elapsedTime = Time.time - startTime;
                        if (elapsedTime < interval)
                        {
                            float remainingTime = interval - elapsedTime;
                            Thread.Sleep((int)(remainingTime * 1000));
                        }
                    }

                    isVibrating = false;
                }
            }
        }
    }
}
