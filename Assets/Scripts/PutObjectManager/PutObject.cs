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


}
