using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Events._7MMEvent;
using Project;
using Sirenix.OdinInspector;
using UnityEngine.UI;
using DG.Tweening;
using Random = UnityEngine.Random;

public class DialogSystem : MonoBehaviour
{
    [SerializeField] Text dialogText;
    [SerializeField] Text nameText;
    [SerializeField] GameObject dialogTextParent;
    [SerializeField] GameObject dialogCanvas;

    [SerializeField] Transform dialogPosition;

    [SerializeField] Animator animator;
    
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] audioClips;
    
    private void Start()
    {
        //dialogCanvas.transform.position = Vector3.zero;
        //dialogCanvas.transform.rotation = Quaternion.Euler(0,90,0);
        EventBus.Subscribe<DialogDetected>(OnDialogDetected);
    }

    [Button]
    public void Test()
    {
        EventBus.Post(new DialogDetected("1-1", null));
    }

    
    private void OnDialogDetected(DialogDetected obj)
    {
        StopAllCoroutines();
        
        
        var events = obj.OnDialogEndEvent;
        var id = obj.dialogID;

        

        StartCoroutine(startDialog());

        IEnumerator startDialog()
        {
            var dialogData = Resources.Load<DialogData>("ScriptableObject/DialogData");
            var dialogDataList = GetDialogDataDetail(id, dialogData);

            SetDialogTextActive(true);

            // dialogCanvas.transform.DOMove(dialogDataList.dialogPosition, 1);
            // dialogCanvas.transform.DORotate(dialogDataList.dialogRotation, 1);
            
            

            foreach (var sentenceDetail in dialogDataList.sentenceDetails)
            {
                if (sentenceDetail.sentence.Length <= 8)
                {
                    audioSource.clip = audioClips[0];
                    animator.Play("Orihime_Talk_0");
                }
                else if(sentenceDetail.sentence.Length > 8 && sentenceDetail.sentence.Length < 18)
                {
                    audioSource.clip = audioClips[1];
                    animator.Play("Orihime_Talk_1");
                }
                else
                {
                    audioSource.clip = audioClips[2];
                    animator.Play("Orihime_Talk_2");
                }


                audioSource.Play();

                
                SetDialogTalkName(sentenceDetail.speaker);
                SetDialogText(sentenceDetail.sentence);
                DetectException(sentenceDetail.sentence);
                
                SetRandomSpineAni();
                yield return new WaitForSeconds(GetGapTime(dialogData));
            }

            SetDialogTextActive(false);
            
            events?.Invoke();
            
            //SetdefaultSpineAni();
            yield return null;
        }
    }


    public DialogDataDetail GetDialogDataDetail(string _ID , DialogData dialogData)
    {
        return dialogData.dialogDataDetails.Where(t => t.ID == _ID).FirstOrDefault();
    }

    float GetGapTime(DialogData dialogData)
    {
        return dialogData.gapTimer;
    }

    void SetDialogTextActive(bool active)
    {
        dialogTextParent.SetActive(active);
    }


    void SetDialogText(string t)
    {
        dialogTextParent.gameObject.SetActive(true);
        dialogText.text = t;
    }

    void DetectException(string sentence)
    {
        if(sentence == "（マウスクリックの音）")
        {
            //播放滑鼠點擊的聲音
        }
    }

    void SetDialogTalkName(Speaker speaker)
    {
        if(speaker == Speaker.SevenMM)
        {
            nameText.text = "織女:";
        }
        else
        {
            nameText.text = "プレイヤー:";
        }
    }

    public void SetRandomSpineAni()
    {
        SevenMMSpineCtr.instance.SetRandomSpineAni();
    }

    public void SetdefaultSpineAni()
    {
        SevenMMSpineCtr.instance.SetdefaultSpineAni();
    }

    public void SetOtherPosition()
    {
        dialogCanvas.transform.position = dialogPosition.position;
        dialogCanvas.transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
    }

}
