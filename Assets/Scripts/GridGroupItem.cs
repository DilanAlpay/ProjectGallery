using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class GridGroupItem : GroupItem
{
    public GridGroupItem north, east, south, west;
       
    public GridGroupItem Move(Vector2 dir)
    {
        if (dir.y > 0)
        {
            return north;
        }
        else if (dir.x > 0)
        {
            return east;
        }
        else if (dir.y < 0)
        {
            return south;
        }
        else if(dir.x < 0)
        {
            return west;
        }

        return null;
    }

    private void OnDrawGizmosSelected()
    {
        if (north)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawRay(transform.position, (north.transform.position - transform.position) / 2);
        }
        if (east)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, (east.transform.position - transform.position) / 2);
        }
        if (south)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.position, (south.transform.position - transform.position) / 2);
        }
        if (west)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawRay(transform.position, (west.transform.position - transform.position) / 2);
        }
    }
}
