using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtectDome : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bullet") || other.CompareTag("EnemyBullet") || other.CompareTag("SpecialBullet"))
        {
            other.gameObject.GetComponent<BulletController>().DestroyBullet(other.gameObject);
        }
    }
}
