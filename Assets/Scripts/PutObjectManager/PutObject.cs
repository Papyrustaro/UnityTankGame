using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private GameObject warp;
    private bool putBomb = false;
    private bool putWarp = false;

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
            GameObject player = GameObject.FindWithTag("Player");
            GameObject shotBullet = player.transform.Find("Cannon/ShotBullet").gameObject;
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

    public void PutBombermanPrefab()
    {
        GameObject ProtectDomePrefab = (GameObject)Instantiate(bombermanPrefab, transform.position, Quaternion.identity);
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
        }
        putWarp = !putWarp;
    }


}
