using System;

namespace Events
{
    public class TeleportEffectDetected
    {
        public Action events;

        public TeleportEffectDetected(Action _events)
        {
            events = _events;
        }
    }
}