using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// An object with an Animator on it that calls UnityEvents during an animation
/// </summary>
[RequireComponent(typeof(Animator))]
public class AnimEventCaller : MonoBehaviour
{
    /// <summary>
    /// All events this object can call with its animation
    /// </summary>
    public List<AnimEventPair> myEvents;

    /// <summary>
    /// Used by an animation to invoke the specified event
    /// </summary>
    /// <param name="ae"></param>
    public void CallEvent(AnimEvent ae)
    {
        foreach (AnimEventPair pair in myEvents)
        {
            if(pair.animEvent == ae)
            {
                pair.myEvent.Invoke();
                break;
            }
        }
    }

    /// <summary>
    /// A UnityEvent paired with an AnimEvent
    /// Animations use the AnimEvent to invoke the UnityEvent
    /// </summary>
    [System.Serializable]
    public struct AnimEventPair
    {
        public AnimEvent animEvent;
        public UnityEvent2 myEvent;
    }
}
