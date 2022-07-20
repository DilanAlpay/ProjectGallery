using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : Listener
{
    public UnityEvent2 response;

    public override void Call()
    {
        response.Invoke();
    }
}
