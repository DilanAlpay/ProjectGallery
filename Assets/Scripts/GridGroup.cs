using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
public class GridGroup : MonoBehaviour
{
    public InputEvent eventMovement;
    public InputEvent eventSelect;
    private GridGroupItem current;
    public GridGroupItem defaultItem;
    public Transform cursor;
    public UnityEvent2 onSelect;

    private void OnEnable()
    {
        if (defaultItem) current = defaultItem;
        MoveToCurrent();


        eventMovement.Action.started += Move;
        if(eventSelect)
        eventSelect.Action.started += Select;
    }

    private void OnDisable()
    {
        eventMovement.Action.started -= Move;
        eventSelect.Action.started -= Select;
    }

    void Move(InputAction.CallbackContext ctx)
    {
        GridGroupItem newItem;
        if (ctx.action.type == InputActionType.Button)
        {
            newItem = current.Move(Vector2.right);
        }
        else
        {
            newItem = current.Move(ctx.ReadValue<Vector2>());
        }


        if (newItem != null)
        {
            current = newItem;
        }

        MoveToCurrent();

    }

    void Select(InputAction.CallbackContext ctx)
    {
        current.Select();
        onSelect.Invoke();
    }

    public void SetCurrentSelection(GridGroupItem newItem)
    {
        current = newItem;
        MoveToCurrent();
    }

    private void MoveToCurrent()
    {
        cursor.transform.position = current.transform.position;
    }
}
