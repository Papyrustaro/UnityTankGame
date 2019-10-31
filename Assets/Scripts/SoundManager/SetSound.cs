using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSound : MonoBehaviour
{
    public AudioClip shotBulletSound;
    public AudioClip destroyTankSound;
    public AudioClip bounceBulletSound;
    public AudioClip selectButtonSound;
    public AudioClip submitSound;

    private void Start()
    {
        SEManager.shotBulletSound = this.shotBulletSound;
        SEManager.destroyTankSound = this.destroyTankSound;
        SEManager.bounceBulletSound = this.bounceBulletSound;
        SEManager.selectButtonSound = this.selectButtonSound;
        SEManager.submitSound = this.submitSound;
    }
}
