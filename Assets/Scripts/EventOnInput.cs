using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
public class EventOnInput : MonoBehaviour
{
    public List<InputEvent> inputs;
    public UnityEvent myEvent;

    private void OnEnable()
    {
        foreach (InputEvent obj in inputs)
        {
            if (obj.Action != null)
                obj.Action.performed += CallEvent;
        }
    }

    private void OnDisable()
    {
        foreach (InputEvent obj in inputs)
        {
            if(obj.Action != null)
                obj.Action.performed -= CallEvent;
        }
    }

    public void CallEvent(InputAction.CallbackContext ctx)
    {
        myEvent.Invoke();
    }
}
