using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionSetObject : MonoBehaviour
{
    public List<OptionObject> objects;
    public OptionSet Set 
    { 
        get 
        {
            OptionSet os = new OptionSet();
            foreach (OptionObject item in objects)
            {
                os.Add(item.option);
            }
            return os; 
        } 
    }


    private int _lastAdded = 0;

    public void AddObject(OptionObject obj)
    {
        objects[_lastAdded].SetOption(obj.option);
        _lastAdded = (_lastAdded + 1) % objects.Count;
    }

    public void SetOption(Option option,int i)
    {
        objects[i].SetOption(option);
    }

    public void Clear()
    {
        foreach (OptionObject obj in objects)
        {
            obj.SetOption(null);
        }
        _lastAdded = 0;
    }

    public void FillWithOptions(List_Option source)
    {
        for (int i = 0; i < objects.Count; i++)
        {
            objects[i].SetOption(source[i]);
        }
    }

    public bool IsEmpty()
    {
        foreach(OptionObject obj in objects)
        {
            if (obj.option != null)
                return false;
        }

        return true;
    }
}
