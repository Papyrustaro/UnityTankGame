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
    public AudioClip shotLaserSound;
    public AudioClip bombSound;
    public AudioClip warpSound;
    public AudioClip destroyBulletSound;
    public AudioClip putBombSound;
    public AudioClip putObjectSound0;
    public AudioClip putObjectSound1;

    private void Start()
    {
        SEManager.shotBulletSound = this.shotBulletSound;
        SEManager.destroyTankSound = this.destroyTankSound;
        SEManager.bounceBulletSound = this.bounceBulletSound;
        SEManager.selectButtonSound = this.selectButtonSound;
        SEManager.submitSound = this.submitSound;
        SEManager.shotLaserSound = this.shotLaserSound;
        SEManager.warpSound = this.warpSound;
        SEManager.bombSound = this.bombSound;
        SEManager.destroyBulletSound = this.destroyBulletSound;
        SEManager.putBombSound = this.putBombSound;
        SEManager.putObjectSound0 = this.putObjectSound0;
        SEManager.putObjectSound1 = this.putObjectSound1;
    }
}
