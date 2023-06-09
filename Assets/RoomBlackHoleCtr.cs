using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine.SceneManagement;

public class RoomBlackHoleCtr : MonoBehaviour
{
    public static RoomBlackHoleCtr instance;

    public Transform playerPos , blackHole;

    private void Awake() {
        instance = this;

        playerPos = FindObjectOfType<RoomSceneCameraCtr>().transform;
    }

    [Button]
    public void StartFadeToTemple()
    {
        blackHole.transform.gameObject.SetActive(true);
        transform.parent = null;

        // DOTween.To(() => tra , x => canvasGroup.alpha = x , 1 ,1)
        //     .SetEase(Ease.Linear);

        transform.DOMove(playerPos.position, 1f).onComplete += delegate
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        };
        
        blackHole.transform.LookAt(playerPos);
    }
}
