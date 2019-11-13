using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEManager : MonoBehaviour
{
    private static AudioSource audioSource;
    public static AudioClip shotBulletSound;
    public static AudioClip destroyTankSound;
    public static AudioClip bounceBulletSound;
    public static AudioClip selectButtonSound;
    public static AudioClip submitSound;

    public static AudioClip destroyBulletSound;
    public static AudioClip shotLaserSound;
    public static AudioClip bombSound;
    public static AudioClip warpSound;
    public static AudioClip putBombSound;
    public static AudioClip putObjectSound0;
    public static AudioClip putObjectSound1;
    public static AudioClip countDownSound;
    public static AudioClip resultSound0;
    public static AudioClip resultSound1;
    public static AudioClip cannotSound;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }

    public static void PlayShotBulletSound()
    {
        audioSource.PlayOneShot(shotBulletSound);
    }

    public static void PlayDestroyTankSound()
    {
        audioSource.PlayOneShot(destroyTankSound);
    }
    public static void PlayBounceBulletSound()
    {
        audioSource.PlayOneShot(bounceBulletSound);
    }
    public static void PlaySelectButtonSound()
    {
        audioSource.PlayOneShot(selectButtonSound);
    }
    public static void PlaySubmitSound()
    {
        audioSource.PlayOneShot(submitSound);
    }
    public static void PlayBombSound()
    {
        audioSource.PlayOneShot(bombSound);
    }
    public static void PlayWarpSound()
    {
        audioSource.PlayOneShot(warpSound);
    }
    public static void PlayShotLaserSound()
    {
        audioSource.PlayOneShot(shotLaserSound);
    }
    public static void PlayDestroyBulletSound()
    {
        audioSource.PlayOneShot(destroyBulletSound);
    }
    public static void PlayPutBombSound()
    {
        audioSource.PlayOneShot(putBombSound);
    }
    public static void PlayPutObjectSound0()
    {
        audioSource.PlayOneShot(putObjectSound0);
    }
    public static void PlayPutObjectSound1()
    {
        audioSource.PlayOneShot(putObjectSound1);
    }
    public static void PlayCannotSound()
    {
        audioSource.PlayOneShot(cannotSound);
    }
}
