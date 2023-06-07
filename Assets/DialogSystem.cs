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


    public void SetDialogText(string t)
    {
        DialogText.text = t;
    }

    // void Start()
    // {
        
    // }

    // void Update()
    // {
        
    // }

    
}
