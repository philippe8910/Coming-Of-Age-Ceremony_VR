using System;

namespace Events._7MMEvent
{
    public class DialogDetected
    {
        public Action OnDialogEndEvent;

        public string dialogID;

        public DialogDetected(string id, Action _action)
        {
            OnDialogEndEvent = _action;
            dialogID = id;
        }
    }
}