using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotShell : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float shotSpeed;
    public float shotIntarval = 60;
    private float IntarvalCount = 0;

    void Update()
    {
        IntarvalCount++;
        if(IntarvalCount % shotIntarval == 0)
        {
            GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

            bulletRb.AddForce(transform.forward * shotSpeed);
        }
    }
}
