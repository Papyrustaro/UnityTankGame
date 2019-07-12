using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void setShotSpeed(float magnification)
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
            GameObject bullet = Instantiate(this.bulletPrefab, enemyShotBullet.transform.position, enemyShotBullet.transform.rotation) as GameObject;
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            BulletController bc = bullet.GetComponent<BulletController>();
            bulletRb.AddForce(enemyShotBullet.transform.forward * bc.getBulletSpeed() * shotSpeedMagni);
            countTime = 0f;
            return true;
        }
    }
    public bool Shot(GameObject bulletPrefab)
    {
        if(ableBulletNum <= bulletNum)
        {
            return false;
        }
        else
        {
            GameObject bullet = Instantiate(bulletPrefab, enemyShotBullet.transform.position, enemyShotBullet.transform.rotation) as GameObject;
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            BulletController bc = bullet.GetComponent<BulletController>();
            bulletRb.AddForce(enemyShotBullet.transform.forward * bc.getBulletSpeed() * shotSpeedMagni);
            return true;
        }
    }
}
