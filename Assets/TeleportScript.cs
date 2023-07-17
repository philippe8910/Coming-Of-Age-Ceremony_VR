using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class TeleportScript : MonoBehaviour
{
    [FormerlySerializedAs("playerCamera")] 
    public Transform playerController , rayRender , cameraRig; // 玩家的攝影機
    public float teleportRange = 10f; // 傳送範圍

    public Vector3 pos = Vector3.zero;
    
    public Text text;

    private void Update()
    {
        text.text = "" + OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).magnitude;
        
        // 檢測右搖桿是否被推動
        if (OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).magnitude > 0.1f)
        {
            rayRender.gameObject.SetActive(true);
            
            RaycastHit hit;
            if (Physics.Raycast(playerController.position, playerController.forward, out hit, teleportRange))
            {
                // 檢查是否碰撞到傳送點
                if (hit.collider.CompareTag("TeleportPoint"))
                {
                    text.text = "Hit";
                    pos = hit.point;
                    StartCoroutine(Teleport(pos));
                }
            }
        }

        // 檢測是否放掉右搖桿
        if (OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).magnitude < 0.1f)
        {
            rayRender.gameObject.SetActive(false);
            
            if(pos != Vector3.zero) StartCoroutine(Teleport(pos));
        }
    }

    private IEnumerator Teleport(Vector3 destination)
    {
        cameraRig.transform.position = destination;

        // 在這裡可以加入任何傳送後的效果或動畫

        yield return new WaitForSeconds(0.1f); // 可以根據需要調整等待時間
    }
}