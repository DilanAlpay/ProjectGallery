using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ChargeObj))]
public class ChargeObjAccelerator : MonoBehaviour
{
    public VarFloat speed;
    private ChargeObj chargeObj;

    // Start is called before the first frame update
    void Awake()
    {
        chargeObj = GetComponent<ChargeObj>();
    }

    // Update is called once per frame
    void Update()
    {
        chargeObj.Rate = speed.value;
    }
}
