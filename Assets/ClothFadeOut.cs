using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ClothFadeOut : MonoBehaviour
{
    public Transform endPos;

    public void StartFadeOut()
    {
        transform.DOMove(endPos.position, 1);

        DOTween.To(() => transform.localScale, x => transform.localScale = x, new Vector3(2, 2, 2), 1);
    }
}
