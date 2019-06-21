﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBullet : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float shotSpeed;
    public int ableBeBulletNum;
    private int bulletNum = 0;

    private void Start()
    {
        bulletNum = 0;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && bulletNum < ableBeBulletNum)
        {
            bulletNum++;
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity) as GameObject;
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            bulletRb.AddForce(transform.forward * shotSpeed);
        }
    }

    public void DestroyBullet()
    {
        bulletNum--;
    }
}
