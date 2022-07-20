using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionSet:List<Option>
{
    /// <summary>
    /// By default, checks to see if the two Lists match each other and are in order
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool MatchesOrder(OptionSet other)
    {
        if (other.Count != Count)
        {
            return false;
        }

        for (int i = 0; i < Count; i++)
        {
            if (this[i] != other[i])
            {
                return false;
            }
        }

        return true;
    }

    public bool MatchesNoOrder(OptionSet other)
    {
        List<Option> given = new List<Option>();

        foreach (Option item in other)
        {
            given.Add(item);
        }

        //Make sure we have all of the same things
        for (int i = 0; i < Count; i++)           
        {
            Option lookingFor = this[i];
            if (lookingFor != null)
            {
                //if what we were given matches us
                if (given.Contains(this[i]))
                {
                    given.Remove(this[i]);
                }
                else
                {
                    return false;
                }
            }
        }

        //Now we need to check for empties

        return true;
    }

    public bool Matches(OptionSet other, bool inOrder)
    {
        if (inOrder)
        {
            return MatchesOrder(other);
        }
        return MatchesNoOrder(other);
    }


}
