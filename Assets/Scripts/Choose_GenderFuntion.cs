using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Choose_GenderFuntion : MonoBehaviour
{
    [Button]
    public void ChooseMail()
    {
        PlayerPrefs.SetInt("isMail" ,1);
        MAKABAKAVideoCtr.instance.StartPlayVideo();
        gameObject.SetActive(false);

        print("選擇:" + PlayerPrefs.GetInt("isMail"));
    }

    [Button]
    public void ChooseFemail()
    {
        PlayerPrefs.SetInt("isMail" ,0);
        MAKABAKAVideoCtr.instance.StartPlayVideo();
        gameObject.SetActive(false);

        print("選擇:" + PlayerPrefs.GetInt("isMail"));

        
    }
}
