using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// An Event that has functions based on whether or not a condition is met
/// </summary>
public class TallyEvent : MonoBehaviour
{
    public enum Requirement
    {
        EQUALS,
        GREATER_THAN,
        LESS_THAN
    }

    public VarInt tally;
    public int requirement;
    public Requirement comparison;

    public UnityEvent2 onMet, onNotMet;

    private void Awake()
    {
        tally.value = 0;
    }

    public void Check()
    {
        bool met = false;

        switch (comparison)
        {
            case Requirement.EQUALS:
                met = tally.value == requirement;
                break;
            case Requirement.GREATER_THAN:
                met = tally.value > requirement;
                break;
            case Requirement.LESS_THAN:
                met = tally.value < requirement;
                break;
            default:
                break;
        }

        if (met)
        {
            onMet.Invoke();
        }
        else
        {
            onNotMet.Invoke();
        }
    }
}
