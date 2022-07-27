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

    
    public void OnUpdate()
    {
        speedObj.value = min + (curve.Evaluate(tallyObj.value / ((float)maxTally)) * max);
    }
}
