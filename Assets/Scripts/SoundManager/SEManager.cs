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

}
