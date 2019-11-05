using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadEffect : MonoBehaviour
{
    public GameObject bombEffect;

    private void Awake()
    {
        if (!EffectManager.isSet)
        {
            EffectManager.bombEffect = this.bombEffect;
        }
    }
}
