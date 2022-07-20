using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
public class Game_Memory : MonoBehaviour
{
    public List<List_Option> options;
    public OptionObject display;
    public InputEvent switchButton;
    public List<OptionSetObject> goals;
    public VarInt score;
    
    public UnityEvent2 onShowPhase;
    public UnityEvent2 onChoosePhase;
    public UnityEvent2 onCorrect;
    public UnityEvent2 onWrong;

    private bool showing = true;
    private OptionSet collected = new OptionSet();
    private int current;
    private int optionsPerGoal = 2;
    private int _pointsPer = 100;
    private List<int> _correct;

    // Start is called before the first frame update
    void Start()
    {
        current = 0;

        score.value = 0;

        EnableControls();
        SetGoal(0);
        SetGoal(1);
        SetGoal(2);
    }

    public void EnableControls()
    {
        switchButton.Action.performed += SwitchPhase;
    }

    public void DisableControls()
    {
        switchButton.Action.performed += SwitchPhase;
    }

    public void SetGoal(int i)
    {
        goals[i].Clear();
        for (int x = 0; x < optionsPerGoal; x++)
        {
            goals[i].SetOption(options[x].GetRandom(), x);
        }             
    }

    public void SwitchPhase(InputAction.CallbackContext ctx)
    {
        showing = !showing;
        if (showing)
        {
            onShowPhase.Invoke();
        }
        else
        {
            onChoosePhase.Invoke();
        }
    }

    public void GetOption(OptionObject oo)
    {
        collected.Add(oo.option);
    }

    public void NextSection()
    {
        current = (current + 1) % options.Count;
    }

    /// <summary>
    /// Sets the current option we are working with back to 0
    /// </summary>
    public void ResetOptions()
    {
        current = 0;
    }

    /// <summary>
    /// Fills the selection area with the different segments
    /// </summary>
    /// <param name="oso"></param>
    public void FillWithOptions(OptionSetObject oso)
    {
        for (int i = 0; i < options[current].Count; i++)
        {
            oso.objects[i].SetOption(options[current][i]);
        }
    }
    public void Check()
    {
        DisableControls();
        Invoke("GetResults",0.5f); 
    }   

    public void GetResults()
    {
        _correct = new List<int>();
        for (int i = 0; i < goals.Count; i++)
        {
            if (goals[i].Set.Matches(collected, false))
            {
                _correct.Add(i);
            }
        }

        if (_correct.Count>0)
        {
            onCorrect.Invoke();
            
        }
        else
        {
            onWrong.Invoke();
        }
    }

    public void Clear()
    {
        while (_correct.Count > 0)
        {
            SetGoal(_correct[0]);
            goals[_correct[0]].GetComponent<ChargeObj>().Charge = 0;
            score.value += _pointsPer;
            _correct.RemoveAt(0);
        }

        collected.Clear();

        EnableControls();
    }
}
