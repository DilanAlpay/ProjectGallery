using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayVariable : MonoBehaviour
{
    public Variable variable;
    private TextMesh _display;

    private void Awake()
    {
        _display = GetComponent<TextMesh>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Display();
    }

    private void Display()
    {
        if (!variable) return;
        _display.text = variable.ToString();
    }
}
