using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DialogSystem : MonoBehaviour
{
    [SerializeField] DialogData dialogData;
    private void Awake() {
        dialogData = Resources.Load<DialogData>("ScriptableObject/DialogData");
    }
    public DialogDataDetail GetDialogData(string _ID)
    {
        return dialogData.dialogDataDetails.Where(t => t.ID == _ID).FirstOrDefault();
    }

    // void Start()
    // {
        
    // }

    // void Update()
    // {
        
    // }

    
}
