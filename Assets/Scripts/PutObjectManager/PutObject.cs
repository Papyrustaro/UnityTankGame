﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutObject : MonoBehaviour
{
    public GameObject batteryPrefab;
    public GameObject protectDomePrefab;
    public GameObject remoteBombPrefab;
    public GameObject remoteBombExplosionPrefab;
    private bool putBomb = false;

    public void PutBatteryPrefab()
    {
        GameObject BatteryPrefab = (GameObject)Instantiate(batteryPrefab, transform.position, transform.rotation);
    }
    public void PutProtectDomePrefab()
    {
        GameObject ProtectDomePrefab = (GameObject)Instantiate(protectDomePrefab, transform.position, Quaternion.identity);
    }
    public void PutRemoteBombPrefab()
    {
        if (!putBomb)
        {
            GameObject shotBullet = GameObject.Find("Player/Cannon/ShotBullet");
            GameObject remoteBomb = Instantiate(remoteBombPrefab, shotBullet.transform.position, Quaternion.identity);
        }
        else
        {
            GameObject remoteBomb = GameObject.Find("RemoteBomb(Clone)");
            GameObject Explosion = Instantiate(remoteBombExplosionPrefab, remoteBomb.transform.position, Quaternion.identity);
            Destroy(remoteBomb);
            Destroy(Explosion, 3f);
        }
        putBomb = !putBomb;
    }


}
