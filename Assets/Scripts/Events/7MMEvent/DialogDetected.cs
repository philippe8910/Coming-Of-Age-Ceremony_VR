using System;

namespace Events._7MMEvent
{
    public class DialogDetected
    {
        public Action OnDialogEndEvent;

        public string dialogID;

        public DialogDetected(Action _action , string id)
        {
            OnDialogEndEvent = _action;
            dialogID = id;
        }
    }
}