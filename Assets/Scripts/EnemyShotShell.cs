using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotShell : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float shotSpeed;
    private float shotIntarval;

    void Update()
    {
        shotIntarval++;
        if(shotIntarval % 60 == 0)
        {
            GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

            bulletRb.AddForce(transform.forward * shotSpeed);
        }
    }
}
