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
    public List<OptionSetObject> builds;
    public VarInt score;
    public List<ChargeDisplay> chargeDisplays;

    public UnityEvent2 onShowPhase;
    public UnityEvent2 onChoosePhase;
    public UnityEvent2 onCheck;
    public UnityEvent2 onCorrect;
    public UnityEvent2 onWrong;

    private bool showing = true;
    //private OptionSet collected = new OptionSet();
    private int current;
    private int optionsPerGoal = 2;
    private int _pointsPer = 100;
    private List<OptionSetObject> _correct;
    private bool _buildStarted;
    private Vector2[] positions;
    // Start is called before the first frame update
    void Start()
    {
        current = 0;

        score.value = 0;

        EnableControls();

        positions = new Vector2[goals.Count];
        int i = 0;

        foreach (OptionSetObject goal in goals)
        {
            SetGoal(goal);
            positions[i] = goal.transform.position;
            i++;
        }

        SetPositions();
    }

    public void EnableControls()
    {
        switchButton.Action.performed += SwitchPhase;
    }

    public void DisableControls()
    {
        switchButton.Action.performed -= SwitchPhase;
    }

    public void SetGoal(OptionSetObject goal)
    {
        goal.Clear();
        for (int x = 0; x < optionsPerGoal; x++)
        {
            goal.SetOption(options[x].GetRandom(), x);
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

    public void StartBuild()
    {
        _buildStarted = true;
    }
    
    public void Check()
    {
        if (!_buildStarted) return;
        
        onCheck.Invoke();        
        Invoke("GetResults", 0.5f);      
    }   

    //Determine if the player has submitted a correct object
    public void GetResults()
    {
        _correct = new List<OptionSetObject>();

        //Go through each of the things we built
        foreach(OptionSetObject build in builds)
        {
            if (!build.IsEmpty())
            {
                //We use this so we know if we found a mmatching goal
                int c = _correct.Count;

                //Go through each goal
                int i = 0;
                while (i < goals.Count && c == _correct.Count)
                {
                    OptionSetObject g = goals[i];
                    //If this matches and we haven't already matched this goal to a different build
                    if (!_correct.Contains(g) && g.Set.Matches(build.Set, false))
                    {
                        _correct.Add(g);
                    }
                    i++;
                }
            }
        }

        if (_correct.Count>0)
        {
            Correct();
        }
        else
        {
            Wrong();
        }

        _buildStarted = false;
    }

    public void Correct()
    {
        onCorrect.Invoke();
        StartCoroutine(AnimateSuccess());
    }

    public void Wrong()
    {
        onWrong.Invoke();
        foreach (OptionSetObject obj in builds)
        {
            obj.GetComponent<Animator>().Play("Wrong");
        }
    }

    public void Clear()
    {
        EnableControls();
    }

    IEnumerator AnimateSuccess()
    {
        //For each correctly built object...
        while (_correct.Count > 0)
        {
            OptionSetObject g = _correct[0];            
            //Come up with a new goal
            SetGoal(g);
            //Reset the goal's timer
            g.GetComponent<ChargeObj>().Charge = 0;
            //Animate what we built going away
            builds[0].GetComponent<Animator>().Play("Correct");
            //Shift the goals to the left

            Vector2 temp = goals[goals.Count - 1].transform.position;

            int goalNum = 0;
            //Find out where our goal is in the list
            while (goals[goalNum] != g)
            {
                goalNum++;
            }
            for (int i = goalNum; i < goals.Count-1; i++)
            {
                goals[i] = goals[i + 1];
            }
            g.transform.position = temp;
            goals[goals.Count - 1] = g;

            SetPositions();

            //Add points
            score.value += _pointsPer;
            //Move on to the next correct build
            _correct.RemoveAt(0);
            yield return new WaitForSeconds(0.33f);
        }       
    }

    public void SetPositions()
    {
        for (int x = 0; x < goals.Count; x++)
        {
            goals[x].transform.position = positions[x];
            chargeDisplays[x].chargeObj = goals[x].GetComponent<ChargeObj>();
        }
    }
}
