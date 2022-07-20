using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VarList<T> : ScriptableObject
{
    public List<T> contents;
    public int Count { get { return contents.Count; } }

    public void Add(T obj)
    {
        contents.Add(obj);
    }

    public T Get(int i)
    {
        if (contents.Count>i)
        {
            return contents[i];
        }
        return default;
    }

    public T GetRandom()
    {
        return contents[Random.Range(0, contents.Count)];
    }

    public List<T> GetContents()
    {
        List<T> newList = new List<T>();
        foreach (T item in contents)
        {
            newList.Add(item);
        }
        return newList;
    }

    public void Clear()
    {
        contents.Clear();
    }

    public T this[int i]
    {
        get { return contents[i]; }
        set { contents[i] = value; }
    }
}
