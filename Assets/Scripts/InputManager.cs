using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Managers the InputEvents that are used by external scripts
/// Assigns them all a single instance of the InputSystem
/// and initializes them
/// </summary>
public class InputManager : MonoBehaviour
{
    public List<InputEvent> events;
    private GameControls _controls;
    private void OnEnable()
    {
        _controls = new GameControls();
        _controls.General.Enable();
        _controls.Pause.Enable();
        foreach (InputEvent inputEvent in events)
        {
            inputEvent.Controls = _controls;
            inputEvent.SetAction();
        }
    }

    private void OnDisable()
    {
        _controls.General.Disable();
        foreach (InputEvent inputEvent in events)
        {
            inputEvent.Clear();
        }
    }

    public void SetPause(bool b)
    {
        if (!b)
        {
            _controls.General.Enable();
        }
        else
        {
            _controls.General.Disable();
        }
    }
}
