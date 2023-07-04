using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine.SceneManagement;

public class RoomBlackHoleCtr : MonoBehaviour
{
    public static RoomBlackHoleCtr instance;

    private void Awake() {
        instance = this;
    }

    [Button]
    public void StartFadeToTemple()
    {
        transform.GetChild(0).gameObject.SetActive(true);

        // DOTween.To(() => tra , x => canvasGroup.alpha = x , 1 ,1)
        //     .SetEase(Ease.Linear);
        transform.DOMoveZ(0, 5).onComplete += delegate{
            //RoomSceneCameraCtr.instance.StartRayDeceted();
            SceneManager.LoadScene("TempleScene");
        };
    }
}
