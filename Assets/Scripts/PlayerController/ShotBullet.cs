using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBullet : MonoBehaviour
{
    public GameObject normalBulletPrefab;
    private float shotSpeedMagni = 1f; //発射速度何倍か
    public int ableBeBulletNum;
    private int bulletNum = 0;
    private int gamePadNum;

    private PlayerTankParameter ptp;
    private void Awake()
    {
        ptp = transform.parent.transform.parent.gameObject.GetComponent<PlayerTankParameter>();
        this.shotSpeedMagni = ptp.GetShotSpeedMagni();
        this.ableBeBulletNum = ptp.GetShotAbleBulletNum();
    }
    private void Start()
    {
        bulletNum = 0;
        gamePadNum = transform.parent.transform.parent.gameObject.GetComponent<GamePadManager>().GetGamePadNum();
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
        bulletRb.AddForce(transform.forward * bc.getBulletSpeed() * shotSpeedMagni);
    }
}
