using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyShotManager : MonoBehaviour
{
    public GameObject bulletPrefab;
    private float shotSpeedMagni = 1f; //発射速度何倍か
    public int ableBulletNum = 5;
    public float shotInterval = 3f;
    private float countTime = 0f;
    private int bulletNum = 0;
    private GameObject enemyShotBullet;

    private void Start()
    {
        this.bulletNum = 0;
        enemyShotBullet = this.transform.Find("Cannon/ShotBullet").gameObject;
    }

    private void Update()
    {
        countTime += Time.deltaTime;
    }

    public void DestroyBullet()
    {
        this.bulletNum--;
    }

    public void SetShotSpeed(float magnification)
    {
        this.shotSpeedMagni *= magnification;
    }

    public bool Shot()
    {
        if (ableBulletNum <= bulletNum || countTime < shotInterval)
        {
            return false;
        }
        else
        {
            bulletNum++;
            GameObject bullet = Instantiate(this.bulletPrefab, enemyShotBullet.transform.position, enemyShotBullet.transform.rotation) as GameObject;
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            BulletController bc = bullet.GetComponent<BulletController>();
            bc.SetShooter(this.gameObject);
            bc.SetShooterTank(this.gameObject);
            SEManager.PlayShotBulletSound();
            bulletRb.AddForce(enemyShotBullet.transform.forward * bc.getBulletSpeed() * shotSpeedMagni);
            countTime = 0f;
            return true;
        }
    }
    public bool Shot(GameObject bulletPrefab)
    {
        if(ableBulletNum <= bulletNum || countTime < shotInterval)
        {
            return false;
        }
        else
        {
            try
            {
                bulletNum++;
                GameObject bullet = Instantiate(bulletPrefab, enemyShotBullet.transform.position, enemyShotBullet.transform.rotation) as GameObject;
                Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
                BulletController bc = bullet.GetComponent<BulletController>();
                bc.SetShooter(this.gameObject);
                bc.SetShooterTank(this.gameObject);
                SEManager.PlayShotBulletSound();
                bulletRb.AddForce(enemyShotBullet.transform.forward * bc.getBulletSpeed() * shotSpeedMagni);
                countTime = 0f;
            }catch(Exception e)
            {
                Debug.Log(e);
            }
            return true;
        }
    }
}
