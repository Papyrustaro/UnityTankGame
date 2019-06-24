﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBullet : MonoBehaviour
{
    public GameObject normalBulletPrefab;
    private float shotSpeedMagni = 1f; //発射速度何倍か
    public int ableBeBulletNum;
    private int bulletNum = 0;

    private void Start()
    {
        bulletNum = 0;
    }

    void Update()
    {
        if(Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }
        if (Input.GetButtonDown("Fire1") && bulletNum < ableBeBulletNum)
        {
            bulletNum++;
            Shot(normalBulletPrefab);
        }
    }

    public void DestroyBullet()
    {
        bulletNum--;
    }

    public void setShotSpeed(float magnification)
    {
        this.shotSpeedMagni *= magnification;
    }
    public void Shot(GameObject bulletPrefab)
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation) as GameObject;
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        BulletController bc = bullet.GetComponent<BulletController>();
        bulletRb.AddForce(transform.forward * bc.getBulletSpeed() * shotSpeedMagni);
    }
}