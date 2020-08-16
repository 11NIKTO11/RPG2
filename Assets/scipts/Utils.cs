using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils 
{
    private static float epsilon = 0.01f;
    public static bool FloatEquality(float a, float b)
    {
        return (Mathf.Abs(a - b) < epsilon);
    }
}

