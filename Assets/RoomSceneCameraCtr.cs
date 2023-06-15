using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSceneCameraCtr : MonoBehaviour
{
    public static RoomSceneCameraCtr instance;
    private void Awake() {
        instance = this;
    }

    bool isdeceted;

    float stareAtTime;

    private void Start() {
        isdeceted = false;
        stareAtTime = 0;
    }

    void Update()
    {
        // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (isdeceted && Physics.Raycast(ray, out hit))
        {
            // Debug.DrawLine(transform.position, hit.transform.position, Color.red, 0.1f, true);
            if(hit.transform.tag == "UserLookPhoto")
            {
                stareAtTime += Time.deltaTime;
                if(stareAtTime > 3)
                {
                    isdeceted = false;
                    print("loadScene");
                    LevelSystem.instance.ChangeState(new RoomFadeToTempleState());
                }
            }
        }
        else
        {
            stareAtTime = 0;
        }
    }

    public void StartRayDeceted()
    {
        isdeceted = true;
        print("strtDected");
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward*10);
    }
}
