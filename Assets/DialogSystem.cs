using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    public static DialogSystem instance;

    [SerializeField] DialogData dialogData;
    [SerializeField] Text DialogText;
    private void Awake() {
        instance = this;
        dialogData = Resources.Load<DialogData>("ScriptableObject/DialogData");
    }


    public DialogDataDetail GetDialogDataDetail(string _ID)
    {
        return dialogData.dialogDataDetails.Where(t => t.ID == _ID).FirstOrDefault();
    }

    public float GetGapTimer()
    {
        return dialogData.gapTimer;
    }

    public void SetDialogTextActive(bool active)
    {
        DialogText.gameObject.SetActive(active);
    }


    public void SetDialogText(string t)
    {
        DialogText.gameObject.SetActive(true);
        DialogText.text = t;
    }

    // void Start()
    // {
        
    // }

    // void Update()
    // {
        
    // }

    
}
