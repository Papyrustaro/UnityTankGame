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

    public int putAbleBatteryNum = 2;
    private int putBatteryNum = 0;
    public int putAbleProtectDomeNum = 2;
    private int putProtectDomeNum = 0;
    public int putAbleWarpPairNum = 2;
    private int putWarpPairNum = 0;
    public int putAbleBomberManNum = 2;
    private int putBomberManNum = 0;
    public int putAbleLaserNum = 2;
    private int putLaserNum = 0;
    public int putAbleSwitchGateNum = 2;
    private int putSwitchGateNum = 0;
    public int putAbleLandMineNum = 2;
    private int putLandMineNum = 0;

    private void Start()
    {
        shotBullet = this.transform.Find("ShotBullet").gameObject;
    }

    public void SetPutAbleLandMineNum(int n)
    {
        this.putAbleLandMineNum = n;
    }
    public bool PutBatteryPrefab()
    {
        if (putBatteryNum < putAbleBatteryNum)
        {
            GameObject battery = Instantiate(batteryPrefab, new Vector3(shotBullet.transform.position.x, 0f, shotBullet.transform.position.z), transform.rotation);
            battery.GetComponent<DestroyTimeAgo>().SetPutter(this.GetComponent<PutObject>());
            battery.GetComponent<DestroyByAttack>().SetPutter(this.GetComponent<PutObject>());
            SEManager.PlayPutObjectSound0();
            putBatteryNum++;
            return true;
        }
        return false;
    }
    public bool PutProtectDomePrefab()
    {
        if (putProtectDomeNum < putAbleProtectDomeNum)
        {            
            GameObject protectDome = Instantiate(protectDomePrefab, transform.position, Quaternion.identity);
            protectDome.GetComponent<DestroyTimeAgo>().SetPutter(this.GetComponent<PutObject>());
            SEManager.PlayPutObjectSound1();
            putProtectDomeNum++;
            return true;
        }
        return false;
    }
    public void PutRemoteBombPrefab()
    {
        if (!putBomb)
        {
            remoteBomb = (GameObject)Instantiate(remoteBombPrefab, new Vector3(shotBullet.transform.position.x, 0f, shotBullet.transform.position.z), Quaternion.identity);
            remoteBomb.GetComponent<RemoteController>().SetController(this.gameObject, shotBullet);
            SEManager.PlayPutBombSound();
            try
            {
                UseSkill us = this.transform.parent.transform.gameObject.GetComponent<UseSkill>();
                us.SetSkillCountTime(9f);
            }
            catch
            {

            }
        }
        else
        {
            SEManager.PlayBombSound();
            GameObject Explosion = (GameObject)Instantiate(remoteBombExplosionPrefab, remoteBomb.transform.position, Quaternion.identity);
            Destroy(remoteBomb);
            Destroy(Explosion, 0.5f);
        }
        putBomb = !putBomb;
    }

    public bool PutBombermanPrefab()
    {
        if (putBomberManNum < putAbleBomberManNum)
        {
            SEManager.PlayPutBombSound();
            GameObject bomberman = Instantiate(bombermanPrefab, transform.position, Quaternion.identity);
            bomberman.GetComponent<BomberMan>().SetPutter(this.GetComponent<PutObject>());
            putBomberManNum++;
            return true;
        }
        return false;
    }
    public bool PutLaserPrefab()
    {
        if(putLaserNum < putAbleLaserNum)
        {
            SEManager.PlayPutObjectSound0();
            GameObject laser = Instantiate(laserPrefab, shotBullet.transform.position, transform.rotation);
            laser.GetComponent<Laser>().SetPutter(this.GetComponent<PutObject>());
            putLaserNum++;
            return true;
        }
        return false;
    }

    public bool PutWarpPrefab()
    {
        if(putWarpPairNum < putAbleWarpPairNum)
        {
            if (!putWarp)
            {
                SEManager.PlayPutObjectSound1();
                warp = (GameObject)Instantiate(warpPrefab, transform.position, Quaternion.identity);
                warp.GetComponent<Warp>().SetPutter(this.GetComponent<PutObject>());
                try
                {
                    UseSkill us = this.transform.parent.transform.gameObject.GetComponent<UseSkill>();
                    us.SetSkillCountTime(2.5f);
                }
                catch
                {

                }
            }
            else
            {
                SEManager.PlayPutObjectSound1();
                GameObject exitwarp = (GameObject)Instantiate(exitWarpPrefab, transform.position, Quaternion.identity);
                warp.GetComponent<Warp>().SetPareWarp(exitwarp);
                exitwarp.GetComponent<Warp>().SetPareWarp(warp);
                exitwarp.GetComponent<Warp>().SetPutter(this.GetComponent<PutObject>());
                putWarpPairNum++;
                StartCoroutine(DelayMethod(10f, () =>
                {
                    exitwarp.GetComponent<Warp>().DestroyWarp();
                }));
            }
            putWarp = !putWarp;
            return true;
        }
        return false;
    }

    public bool PutSwitchGatePrefab()
    {
        if (putSwitchGateNum < putAbleSwitchGateNum)
        {
            SEManager.PlayPutObjectSound0();
            GameObject switchGate = Instantiate(switchGatePrefab, new Vector3(shotBullet.transform.position.x, 0f, shotBullet.transform.position.z), transform.rotation);
            switchGate.GetComponent<DestroyTimeAgo>().SetPutter(this.GetComponent<PutObject>());
            switchGate.GetComponent<DestroyByAttack>().SetPutter(this.GetComponent<PutObject>());
            putSwitchGateNum++;
            return true;
        }
        return false;
    }

    public bool PutLandMinePrefab()
    {
        if(putLandMineNum < putAbleLandMineNum)
        {
            SEManager.PlayPutBombSound();
            GameObject landMine = (GameObject)Instantiate(landMinePrefab, transform.position, Quaternion.identity);
            landMine.GetComponent<LandMine>().SetPutter(this.GetComponent<PutObject>());
            putLandMineNum++;
            return true;
        }
        return false;
    }
    public void DestroyObject(GameObject gameObject)
    {
        if(gameObject.name == "Shooter(Clone)")
        {
            this.putBatteryNum--;
            return;
        }
        if(gameObject.name == "ProtectDome(Clone)")
        {
            this.putProtectDomeNum--;
            return;
        }
        if(gameObject.name == "SwitchGate(Clone)")
        {
            this.putSwitchGateNum--;
            return;
        }
    }
    public void DestroyLaser()
    {
        this.putLaserNum--;
    }
    public void BomberManBomb()
    {
        this.putBomberManNum--;
    }
    public void DestroyWarp()
    {
        this.putWarpPairNum--;
    }
    public void LandMineBomb()
    {
        this.putLandMineNum--;
    }

    public GameObject GetRemoteBomb()
    {
        return this.remoteBomb;
    }

    private IEnumerator DelayMethod(float waitTime, Action action)
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }


}
