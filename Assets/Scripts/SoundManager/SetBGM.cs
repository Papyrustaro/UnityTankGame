using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SetBGM : MonoBehaviour
{
    public int BGMNum;
    public AudioClip menuBGM;
    public AudioClip battleBGM;

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
                        audioSource.clip = menuBGM;
                        audioSource.Play();
                        break;
                    case 2:
                        audioSource.clip = battleBGM;
                        audioSource.Play();
                        break;
                    default:
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
