using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class SevenMMSpineCtr : MonoBehaviour
{
    public static SevenMMSpineCtr instance;

    private void Awake() {
        instance = this;
    }

    
    SkeletonAnimation skeletonAnimation;
    Spine.AnimationState spineAnimationState;

    [SpineAnimation]
    [SerializeField] string floatAniName;

    [SpineAnimation]
    [SerializeField] string restAniName;
    

    void Start()
    {
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        spineAnimationState = skeletonAnimation.AnimationState;
    }

    public void SetRandomSpineAni()
    {
        if(Random.Range(0,100) < 70)
        {
            spineAnimationState.SetAnimation(0, floatAniName, true);
        }
        else
        {
            spineAnimationState.SetAnimation(0, restAniName, true);
        }
    }

    public void SetdefaultSpineAni()
    {
        spineAnimationState.SetAnimation(0, floatAniName, true);
    }
}
