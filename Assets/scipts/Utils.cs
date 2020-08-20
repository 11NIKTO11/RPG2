using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils 
{
    private static readonly float epsilon = 1/128f;
    public static bool FloatEquality(float a, float b)
    {
        return (Mathf.Abs(a - b) < epsilon);
    }
}

