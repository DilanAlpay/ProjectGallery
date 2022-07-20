using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    private bool _isMoving;
    public bool moveOnStart;
    public float speed;
    public bool loop;
    public Path path;

    /// <summary>
    /// The point we are currently moving from
    /// </summary>
    public int currentPoint;

    /// <summary>
    /// Whether we move positively or negatively along our path
    /// </summary>
    public int direction = 1;

    /// <summary>
    /// The point we are currently moving towards
    /// </summary>
    private int nextPoint;

    /// <summary>
    /// If true, this object stops at each point along the path
    /// </summary>
    public bool makeStops = false;

    private void Start()
    {
        nextPoint = currentPoint + direction;
        _isMoving = moveOnStart;
    }

    private void Update()
    {
        if (_isMoving)
        {
            Move();
        }
    }

    /// <summary>
    /// Called in Update to keep the object constantly moving towards the next point in the path
    /// </summary>
    public void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, path.Get(nextPoint), speed * Time.deltaTime);

        if (ReachedPoint())
        {
            currentPoint = nextPoint;
            nextPoint = currentPoint + direction;
            if (loop)
            {
                if (nextPoint < 0) nextPoint = path.Count - 1;
                else if (nextPoint >= path.Count) nextPoint = 0;
            }
            else
            {
                nextPoint = Mathf.Clamp(nextPoint, 0, path.Count - 1);
                _isMoving = false;
            }
        }
    }

    public bool ReachedPoint()
    {
        return transform.position == path.Get(nextPoint);
    }

    /// <summary>
    /// Tells the object to start moving towards a specific point in the path
    /// Turns on isMoving
    /// </summary>
    /// <param name="p"></param>
    public void GoTo(int p)
    {
        nextPoint = p;
        _isMoving = true;
    }

    /// <summary>
    /// Moves the object instantly to the next point
    /// </summary>
    /// <param name="p"></param>
    public void WarpTo(int p)
    {
        nextPoint = p;
        transform.position = path.Get(nextPoint);
        currentPoint = p;
    }

    /// <summary>
    /// Alters the speed by a value
    /// </summary>
    /// <param name="s"></param>
    public void ChangeSpeed(float s)
    {
       
    }

    /// <summary>
    /// Instantly sets the speed to be this value
    /// </summary>
    /// <param name="s"></param>
    public void SetSpeed(float s)
    {

    }
}
