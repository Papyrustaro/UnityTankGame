using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugData : MonoBehaviour
{
    public void OnDebugPress()
    {
        PlayerPrefs.SetInt("PlayMissionCount", 9);
        PlayerPrefs.SetInt("PlaySurvivalCount", 9);
    }
}
