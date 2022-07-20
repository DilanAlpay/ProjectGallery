using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
/// A SoloGroup is when there are multiple objects in a list
/// but only one of them is turned on at any given time
/// </summary>
public class SoloGroup : MonoBehaviour
{
    public bool loops;
    public List<GroupItem> items;
    public int current = 0;
    public InputEvent inputPrev, inputNext;
    public InputEvent inputSelect;

    private void Start()
    {
        for (int i = 0; i < items.Count; i++)
        {
            items[i].gameObject.SetActive(i == current);
        }
        //if(inputSelect) inputSelect.Action.started += Select;
       
    }

    private void OnEnable()
    {
        inputPrev.Action.started += GoPrevious;
        inputNext.Action.started += GoNext;
    }

    private void OnDisable()
    {
        if (inputSelect != null) inputSelect.Action.started -= Select;
        inputPrev.Action.started -= GoPrevious;
        inputNext.Action.started -= GoNext;
    }

    public void Select(InputAction.CallbackContext ctx)
    {
        items[current].Select();
    }

    public void GoNext(InputAction.CallbackContext ctx)
    {
        items[current].gameObject.SetActive(false);
        current = current + 1;
        if (loops)
        {
            current = current % items.Count;
        }

        current = Mathf.Clamp(current, 0, items.Count - 1);
        items[current].gameObject.SetActive(true);
    }

    public void GoPrevious(InputAction.CallbackContext ctx)
    {
        items[current].gameObject.SetActive(false);

        current = current - 1;
        if (loops&&current<0)
        {
            current = items.Count - 1;
        }

        current = Mathf.Clamp(current, 0, items.Count - 1);
        items[current].gameObject.SetActive(true);
    }

    
}
