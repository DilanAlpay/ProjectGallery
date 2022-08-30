using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeDisplay : MonoBehaviour
{
    private Animator anim;
    public ChargeObj chargeObj;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("charge", chargeObj.Charge);
    }
}
