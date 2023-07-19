using System;

namespace Events
{
    public class ChangeScenesEffectDetected
    {
        public Action events;

        public ChangeScenesEffectDetected(Action _events)
        {
            events = _events;
        }
    }
}