using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadBGM : MonoBehaviour
{
    public AudioClip menuBGM;
    public AudioClip singleMissionBGM0;
    public AudioClip singleMissionBGM1;
    public AudioClip survivalBGM;

    private void Start()
    {
        BGMManager.menuBGM = this.menuBGM;
        BGMManager.singleMissionBGM0 = this.singleMissionBGM0;
        BGMManager.singleMissionBGM1 = this.singleMissionBGM1;
        BGMManager.survivalBGM = this.survivalBGM;
    }
}
