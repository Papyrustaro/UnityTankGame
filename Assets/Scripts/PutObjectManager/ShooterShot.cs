using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterShot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float shotInterval = 5f;
    private float countTime = 0f;

    private void Update()
    {
        countTime += Time.deltaTime;
        if(shotInterval <= countTime)
        {
            Shot();
            countTime = 0f;
        }
    }

    public void Shot()
    {
        GameObject bullet = Instantiate(this.bulletPrefab, this.transform.position, this.transform.rotation) as GameObject;
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        BulletController bc = bullet.GetComponent<BulletController>();
        bulletRb.AddForce(this.transform.forward * bc.getBulletSpeed());
    }
}
