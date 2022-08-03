using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{
    public InputEvent inputPause;
    public GameEvent pauseStart, pauseEnd;
    private bool paused = false;

    // Start is called before the first frame update
    void OnEnable()
    {
        inputPause.Action.performed += OnPausePressed;        
    }

    private void OnDisable()
    {
        if (inputPause.IsSet)
        {
            inputPause.Action.performed -= OnPausePressed;
        }
    }

    public void OnPausePressed(InputAction.CallbackContext ctx)
    {
        paused = !paused;
        if (paused)
        {
            pauseStart.Call();
            Time.timeScale = 0;
        }
        else
        {
            pauseEnd.Call();
            Time.timeScale = 1;
        }
    }
}
