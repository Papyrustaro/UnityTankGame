using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEManager : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip shotBulletSound;
    public AudioClip destroyTankSound;
    public AudioClip bounceBulletSound;
    public AudioClip selectButtonSound;
    public AudioClip submitSound;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayShotBulletSound()
    {
        audioSource.PlayOneShot(this.shotBulletSound);
    }
    public void PlayDestroyTankSound()
    {
        audioSource.PlayOneShot(this.destroyTankSound);
    }
    public void PlayBounceBulletSound()
    {
        audioSource.PlayOneShot(this.bounceBulletSound);
    }
    public void PlaySelectButtonSound()
    {
        audioSource.PlayOneShot(this.selectButtonSound);
    }
    public void PlaySubmitSound()
    {
        audioSource.PlayOneShot(this.submitSound);
    }
}
