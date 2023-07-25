using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test : MonoBehaviour
{
    public static Test instance;

    private void Awake() {
        instance = this;
    }
    
    public void DebugUse(bool isActive)
    {
        transform.GetChild(0).gameObject.SetActive(isActive);
    }




    public void ToNextScene()
    {
        SceneManager.LoadScene("TempleScene");
    }

    public void ResetAllGame()
    {
        SceneManager.LoadScene("RoomScene");
    }
}
