using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class TestControls : MonoBehaviour
{
    GameControls _input;
    
    private Foo foo;
    public void Hello()
    {
        print("Hello");
    }

    private void Awake()
    {
        _input = new GameControls();
        _input.General.Movement.performed += Doo;
        _input.General.Movement.started += Boo;
    }

    public void Doo(InputAction.CallbackContext ctx)
    {
        Debug.Log("Howdy!");
    }

    public void Boo(InputAction.CallbackContext ctx)
    {
        Debug.Log("Peace");

    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }
}

public class Foo
{
    public InputAction action;

    public Foo(InputAction a)
    {
        action = a;
    }
}