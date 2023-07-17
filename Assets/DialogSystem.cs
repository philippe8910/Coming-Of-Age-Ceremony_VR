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

public class DialogSystem : MonoBehaviour
{
    [SerializeField] Text dialogText;
    [SerializeField] GameObject dialogTextParent;
    [SerializeField] GameObject dialogCanvas;
    
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

            dialogCanvas.transform.DOMove(dialogDataList.dialogPosition, 1);
            dialogCanvas.transform.DORotate(dialogDataList.dialogRotation, 1);
            
            

            foreach (var sentence in dialogDataList.sentences)
            {
                SetDialogText(sentence);
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

    public float GetGapTime(DialogData dialogData)
    {
        return dialogData.gapTimer;
    }

    public void SetDialogTextActive(bool active)
    {
        dialogTextParent.SetActive(active);
    }


    public void SetDialogText(string t)
    {
        dialogTextParent.gameObject.SetActive(true);
        dialogText.text = t;
    }

    public void SetRandomSpineAni()
    {
        SevenMMSpineCtr.instance.SetRandomSpineAni();
    }

    public void SetdefaultSpineAni()
    {
        SevenMMSpineCtr.instance.SetdefaultSpineAni();
    }

}
