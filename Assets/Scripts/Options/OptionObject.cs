using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionObject : MonoBehaviour
{
    public Option option;
    private SpriteRenderer display;

    private void Awake()
    {
        display = GetComponent<SpriteRenderer>();            
    }

    private void Start()
    {
        Display();   
    }

    private void Display()
    {
        if (display == null) return;
        display.sprite = (option != null) ? option.sprite : null;
    }

    public void CallEvent(GameEvent gameEvent)
    {
        gameEvent.Call(this);
    }

    public void SetOption(Option op)
    {
        option = op;
        Display();
    }

    public void SetOptionFromObject(OptionObject obj)
    {
        SetOption(obj.option);
    }
}
