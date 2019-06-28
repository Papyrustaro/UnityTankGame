﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtectDome : MonoBehaviour
{
    private ShotBullet sb;
    private void OnTriggerEnter(Collider other)
    {
        sb = GameObject.Find("Player/Cannon/ShotBullet").GetComponent<ShotBullet>();
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            sb.DestroyBullet();
        }
        if (other.gameObject.CompareTag("EnemyBullet") || other.gameObject.CompareTag("SpecialBullet"))
        {
            Destroy(other.gameObject);
        }
    }
}