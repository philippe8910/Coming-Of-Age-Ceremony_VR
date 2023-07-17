using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TeleportEvent : MonoBehaviour
{
    public UnityEvent OnTeleportEnd;

    public void TeleportEnd()
    {
        OnTeleportEnd?.Invoke();
    }
}
