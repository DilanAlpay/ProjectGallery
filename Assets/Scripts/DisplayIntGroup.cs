using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayIntGroup : MonoBehaviour
{
    public VarInt variable;
    public bool invert;
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive((!invert ? i < variable.value : !(i < variable.value)));
        }
    }
}
