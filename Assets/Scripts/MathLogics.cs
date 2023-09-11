using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathLogics : MonoBehaviour
{
    public Vector2 UnitVectorMaker(Vector3 targetPos)
    {
        var horizontal = 0f;
        var vertical = 0f;
        Vector3 deltaVector = (targetPos - transform.position);
        if (Math.Abs(targetPos.y - transform.position.y) > 0.01)
        {
            vertical = deltaVector.y / Math.Abs(deltaVector.y);
        }

        if (Math.Abs(targetPos.x - transform.position.x) > 0.01)
        {
            horizontal = deltaVector.x / Math.Abs(deltaVector.x);
        }

        Vector2 result = new Vector2(horizontal, vertical);
        return result;
    }
}
