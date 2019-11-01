using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySE : MonoBehaviour
{
    public void PlaySelectButtonSound()
    {
        SEManager.PlaySelectButtonSound();
    }
    public void PlaySubmitButtonSound()
    {
        SEManager.PlaySubmitSound();
    }
}
