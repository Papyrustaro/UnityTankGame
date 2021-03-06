﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSE : MonoBehaviour
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
    public AudioClip countDownSound;
    public AudioClip resultSound0;
    public AudioClip resultSound1;
    public AudioClip cannotSound;
    public AudioClip correctSound;
    public AudioClip incorrectSound;

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
        SEManager.countDownSound = this.countDownSound;
        SEManager.resultSound0 = this.resultSound0;
        SEManager.resultSound1 = this.resultSound1;
        SEManager.cannotSound = this.cannotSound;
        SEManager.correctSound = this.correctSound;
        SEManager.incorrectSound = this.incorrectSound;
    }
}
