using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugData : MonoBehaviour
{
    public void OnDebugPress()
    {
        for(int i = 21; i <= 27; i++)
        {
            PlayerPrefs.SetInt("UseableTank" + i, 1);
        }
        //PlayerPrefs.SetInt("PlayMissionCount", 9);
        //PlayerPrefs.SetInt("PlaySurvivalCount", 9);
    }
}
