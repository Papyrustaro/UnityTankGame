using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SetBGM : MonoBehaviour
{
    public int BGMNum; //1:menu, 2:singleMission0, 3:singleMission1, 4:survival

    private void Awake()
    {
        try
        {
            if (BGMManager.BGMNum != this.BGMNum)
            {
                AudioSource audioSource = GameObject.Find("SoundManager").GetComponent<AudioSource>();
                switch (this.BGMNum)
                {
                    case 1:
                        audioSource.clip = BGMManager.menuBGM;
                        audioSource.Play();
                        break;
                    case 2:
                        audioSource.clip = BGMManager.singleMissionBGM0;
                        audioSource.Play();
                        break;
                    case 3:
                        audioSource.clip = BGMManager.singleMissionBGM1;
                        audioSource.Play();
                        break;
                    case 4:
                        audioSource.clip = BGMManager.survivalBGM;
                        audioSource.Play();
                        break;
                    default:
                        audioSource.Stop();
                        break;
                }
                BGMManager.BGMNum = BGMNum;
            }
        }catch(Exception e)
        {
            Debug.Log(e);
        }
    }
}
