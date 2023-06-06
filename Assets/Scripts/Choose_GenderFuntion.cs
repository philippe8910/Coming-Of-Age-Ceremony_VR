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
        gameObject.SetActive(false);

        print(PlayerPrefs.GetInt("isMail"));
    }

    [Button]
    public void ChooseFemail()
    {
        PlayerPrefs.SetInt("isMail" ,0);
        gameObject.SetActive(false);

        print(PlayerPrefs.GetInt("isMail"));
    }
}
