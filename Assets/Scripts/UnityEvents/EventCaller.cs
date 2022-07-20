using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EventCaller : MonoBehaviour
{
    [Header("Properties")]

    /// <summary>
    /// If true, this event is called when this object is enabled
    /// </summary>
    public bool callOnEnable;

    /// <summary>
    /// The max amount of times this event can be called before the component is destroyed
    /// If 0 it can be called repeatedly
    /// </summary>
    public int maxCalls;
    
    /// <summary>
    /// If we call on start, how long we wait before calling the Event
    /// </summary>
    public float initialDelay;

    /// <summary>
    /// Time after calling the Event before it is Invoked
    /// </summary>
    public float delay;

    [Header("Event")]
    /// <summary>
    /// Event invoked by this Caller
    /// </summary>
    public UnityEvent2 myEvent;

    /// <summary>
    /// Coroutine of the event currently being invoked
    /// </summary>
    private IEnumerator current;

    private void OnEnable()
    {
        if (callOnEnable)
        {
            CallEventDelayed(initialDelay);
        }
    }

    /// <summary>
    /// Attempts to call the event, potentially after a delay
    /// </summary>
    public void CallEvent()
    {
        CallEventDelayed(delay);
    }

    public void CallEventDelayed(float f)
    {
        current = CurrentInvoke(f);
        StartCoroutine(current);
    }

    /// <summary>
    /// Invokes the UnityEvent without delay
    /// </summary>
    public void CallNow()
    {
        myEvent.Invoke();
        maxCalls--;
        if(maxCalls == 0)
        {
            Destroy(this);
        }
    }

    private IEnumerator CurrentInvoke(float t)
    {
        yield return new WaitForSeconds(t);
        CallNow();
        current = null;
    }

    public void StopDelayedEvent()
    {
        if (current==null)
            return;
        StopCoroutine(current);
    }

    



}
