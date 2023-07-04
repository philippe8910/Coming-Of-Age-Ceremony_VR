using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Events._7MMEvent;
using Project;
using Sirenix.OdinInspector;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    [SerializeField] Text dialogText;
    
    private void Start()
    {
        EventBus.Subscribe<DialogDetected>(OnDialogDetected);
    }

    [Button]
    public void Test()
    {
        EventBus.Post(new DialogDetected(null, "1-1"));
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
            
            foreach (var sentence in dialogDataList.sentences)
            {
                SetDialogText(sentence);
                yield return new WaitForSeconds(GetGapTime(dialogData));
            }
            
            events?.Invoke();
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
        dialogText.gameObject.SetActive(active);
    }


    public void SetDialogText(string t)
    {
        dialogText.gameObject.SetActive(true);
        dialogText.text = t;
    }

}
