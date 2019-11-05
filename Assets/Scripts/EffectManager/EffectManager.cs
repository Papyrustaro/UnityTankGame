using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public static GameObject bombEffect;
    public static bool isSet = false;

    public static void ShowBombEffect(Vector3 v)
    {
        GameObject Explosion = (GameObject)Instantiate(EffectManager.bombEffect, v, Quaternion.identity);
        Destroy(Explosion, 0.5f);
    }
}
