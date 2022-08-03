using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "InputEvent")]
public class InputEvent : ScriptableObject
{
    private InputAction _action;
    private GameControls _controls;

    public InputAction Action { get { return _action; } }
    public GameControls Controls { get { return _controls; } set { _controls = value; } }
    public bool IsSet {  get { return _action != null; } }
    /// <summary>
    /// Generates the InputAction associated with this object using its file name
    /// </summary>
    public void SetAction()
    {
        _action = _controls.FindAction(name);
    }

    public void Clear()
    {
        _controls = null;
        _action = null;
    }
}

