using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public bool showPath;
    public Color color = Color.red;
    public float pointRadius = 0.25f;
    public bool showLoop;
    public int Count {  get { return transform.childCount; } }

    private void OnDrawGizmos()
    {
        if (!showPath || transform.childCount == 0) return;
        Gizmos.color = color;
        Gizmos.DrawSphere(transform.GetChild(0).position, pointRadius);
        for (int i = 1; i < transform.childCount; i++)
        {
            Gizmos.DrawSphere(transform.GetChild(i).position, pointRadius);
            Gizmos.DrawLine(transform.GetChild(i - 1).position, transform.GetChild(i).position);
        }

        if (showLoop)
        {
            Gizmos.DrawLine(transform.GetChild(transform.childCount - 1).position, transform.GetChild(0).position);
        }
    }

    public Vector3 Get(int p)
    {
        return transform.GetChild(p).position;
    }
}
