using System;
using UnityEngine;

public static class VectorMathUtils
{
    public static float GetVectorPointDistance(Vector3 pointA, Vector3 pointB)
    {
        var xComponent = Mathf.Pow(pointA.x - pointB.x, 2);
        var yComponent = Mathf.Pow(pointA.y - pointB.y, 2);
        var zComponent = Mathf.Pow(pointA.z - pointB.z, 2);

        return Mathf.Sqrt(xComponent + yComponent + zComponent);
    }

    /*public static float GetVectorDotProduct()
    {
        
    }*/
}
