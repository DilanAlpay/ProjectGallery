using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class GroupItem : MonoBehaviour
{
    public UnityEvent2 onSelect;
    public UnityEvent2 onFocus;
    public UnityEvent2 onLeave;

    public void SetFocus(bool b)
    {
        if (b) onFocus.Invoke();
        else onLeave.Invoke();
    }

    public void Select()
    {
        onSelect.Invoke();
    }
}
