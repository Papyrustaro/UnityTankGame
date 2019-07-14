using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PutObject : MonoBehaviour
{
    public GameObject batteryPrefab;
    public GameObject protectDomePrefab;
    public GameObject remoteBombPrefab;
    public GameObject remoteBombExplosionPrefab;
    public GameObject bombermanPrefab;
    public GameObject laserPrefab;
    public GameObject warpPrefab;
    public GameObject exitWarpPrefab;
    public GameObject switchGatePrefab;
    public GameObject landMinePrefab;
    private GameObject shotBullet;

    private GameObject warp;
    private GameObject remoteBomb;
    private bool putBomb = false;
    private bool putWarp = false;
    public int putAbleLandMineNum = 2;
    private int putLandMineNum = 0;

    private void Start()
    {
        shotBullet = this.transform.Find("ShotBullet").gameObject;
    }
    public void PutBatteryPrefab()
    {
        Instantiate(batteryPrefab, transform.position, transform.rotation);
    }
    public void PutProtectDomePrefab()
    {
        Instantiate(protectDomePrefab, transform.position, Quaternion.identity);
    }
    public void PutRemoteBombPrefab()
    {
        if (!putBomb)
        {
            remoteBomb = (GameObject)Instantiate(remoteBombPrefab, shotBullet.transform.position, Quaternion.identity);
            remoteBomb.GetComponent<RemoteController>().SetController(this.gameObject, shotBullet);
        }
        else
        {
            GameObject Explosion = (GameObject)Instantiate(remoteBombExplosionPrefab, remoteBomb.transform.position, Quaternion.identity);
            Destroy(remoteBomb);
            Destroy(Explosion, 0.5f);
        }
        putBomb = !putBomb;
    }

    public void PutBombermanPrefab()
    {
        Instantiate(bombermanPrefab, transform.position, Quaternion.identity);
    }
    public void PutLaserPrefab()
    {
        Instantiate(laserPrefab, transform.position, transform.rotation);
    }

    public void PutWarpPrefab()
    {
        if (!putWarp)
        {
            warp = (GameObject)Instantiate(warpPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            GameObject exitwarp = (GameObject)Instantiate(exitWarpPrefab, transform.position, Quaternion.identity);
            warp.GetComponent<Warp>().SetPareWarp(exitwarp);
            exitwarp.GetComponent<Warp>().SetPareWarp(warp);
            StartCoroutine(DelayMethod(10f, () =>
            {
                exitwarp.GetComponent<Warp>().DestroyWarp();
            }));
        }
        putWarp = !putWarp;
    }

    public void PutSwitchGatePrefab()
    {
        Instantiate(switchGatePrefab, shotBullet.transform.position, transform.rotation);
    }

    public void PutLandMinePrefab()
    {
        if(putLandMineNum < putAbleLandMineNum)
        {
            GameObject landMine = (GameObject)Instantiate(landMinePrefab, transform.position, Quaternion.identity);
            landMine.GetComponent<LandMine>().SetPutter(this.GetComponent<PutObject>());
            putLandMineNum++;
        }
    }
    public void LandMineBomb()
    {
        this.putLandMineNum--;
    }

    private IEnumerator DelayMethod(float waitTime, Action action)
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }


}
