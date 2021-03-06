﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ShotBullet : MonoBehaviour
{
    public GameObject normalBulletPrefab;
    private float shotSpeedMagni = 1f; //発射速度何倍か
    public int ableBeBulletNum;
    private int bulletNum = 0;
    private int gamePadNum;
    private TankMovement tm;
    private Text bulletText;

    private PlayerTankParameter ptp;
    private void Awake()
    {
        ptp = transform.parent.transform.parent.gameObject.GetComponent<PlayerTankParameter>();
        this.shotSpeedMagni = ptp.GetShotSpeedMagni();
        this.ableBeBulletNum = ptp.GetShotAbleBulletNum();
        tm = this.transform.root.gameObject.GetComponent<TankMovement>();
    }
    private void Start()
    {
        bulletNum = 0;
        gamePadNum = transform.parent.transform.parent.gameObject.GetComponent<GamePadManager>().GetGamePadNum();
        bulletText = GameObject.Find("BulletNumCanvas/BulletText").GetComponent<Text>();
        bulletText.text = (ableBeBulletNum - bulletNum).ToString();
    }

    void Update()
    {
        if(Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }
        if (Input.GetButtonDown(GamePadManager.padFire1[gamePadNum]) && bulletNum < ableBeBulletNum)
        {
            bulletNum++;
            Shot(normalBulletPrefab);
        }
    }

    public void DestroyBullet()
    {
        bulletNum--;
        bulletText.text = (ableBeBulletNum - bulletNum).ToString();
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
        bc.SetShooter(this.gameObject);
        bc.SetShooterTank(this.transform.parent.transform.parent.gameObject);
        bulletRb.AddForce(transform.forward * bc.getBulletSpeed() * shotSpeedMagni);
        SEManager.PlayShotBulletSound();
        tm.SetAbleMove(false);

        bulletText.text = (ableBeBulletNum - bulletNum).ToString();
        StartCoroutine(DelayMethod(0.2f, () =>
        {
            tm.SetAbleMove(true);
        }));
    }

    private IEnumerator DelayMethod(float waitTime, Action action)
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }
}
