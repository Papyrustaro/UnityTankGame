using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    private bool dontDestroyEnabled = true;
    private static AudioSource audioSource;
    public static float baseVolume = 1f;

    public static AudioClip menuBGM;
    public static AudioClip singleMissionBGM0;
    public static AudioClip singleMissionBGM1;
    public static AudioClip survivalBGM;

    public static int BGMNum; //menu:1, singleMission0:2, singleMission1:3, survival:4

    static BGMManager _instance = null;

    static BGMManager instance
    {
        get { return _instance ?? (_instance = FindObjectOfType<BGMManager>()); }
    }
    private void Awake()
    {
        //オブジェクトが重複していたら破棄
        if(this != instance)
        {
            Destroy(this.gameObject);
            return;
        }

        if (this.dontDestroyEnabled)
        {
            DontDestroyOnLoad(this.gameObject);
        }
        audioSource = GetComponent<AudioSource>();
    }

    public void OnDestroy()
    {
        if (this == instance) _instance = null;
    }
    public void SetDontDestroyEnabled(bool flag)
    {
        this.dontDestroyEnabled = flag;
    }

    public void SetNewBGM(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
    }

    public static void SetVolume(float volume)
    {
        audioSource.volume = baseVolume * volume;
    }
    public static float GetVolume()
    {
        return audioSource.volume;
    }
}
