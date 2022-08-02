using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerator : MonoBehaviour
{
    public VarInt tallyObj;
    public VarFloat speedObj;
    public float min, max;
    public int maxTally;
    public AnimationCurve curve;

    private void Awake()
    {
        OnUpdate();
    }
    public void OnUpdate()
    {
        float percent = tallyObj.value / (float)maxTally;
        float val = Mathf.Lerp(min, max, (curve.Evaluate(percent)));
        speedObj.value = val;
    }
}
