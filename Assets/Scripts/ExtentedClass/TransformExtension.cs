using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TransformExtension
{
    private static Vector3 vector3;
    public static void SetEulerAnglesY(this Transform transform, float y)
    {
        vector3.Set(transform.localEulerAngles.x, y, transform.localEulerAngles.z);
        transform.eulerAngles = vector3;
    }
    public static void SetLocalEulerAnglesY(this Transform transform, float y)
    {
        vector3.Set(transform.localEulerAngles.x, y, transform.localEulerAngles.z);
        transform.localEulerAngles = vector3;
    }
}
