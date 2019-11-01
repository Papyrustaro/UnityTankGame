using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LandMine : MonoBehaviour
{
    public GameObject explosionPrefab;
    public Material beforeExplosionMaterial;
    private PutObject po;

    private void Start()
    {
        StartCoroutine(DelayMethod(5f, () =>
        {
            SetColorRed();
        }));
        StartCoroutine(DelayMethod(7f, () =>
        {
            Bomb();
        }));
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bullet") || other.CompareTag("SpecialBullet") || other.CompareTag("EnemyBullet"))
        {
            other.gameObject.GetComponent<BulletController>().DestroyBullet(other.gameObject);
            Bomb();
        }else if(other.CompareTag("AttackFlag"))
        {
            Bomb();
        }
    }

    public void Bomb()
    {
        try
        {
            po.LandMineBomb();
        }
        catch (MissingReferenceException)
        {
        }
        SEManager.PlayBombSound();
        GameObject Explosion = (GameObject)Instantiate(explosionPrefab, this.transform.position, Quaternion.identity);
        this.gameObject.SetActive(false);
        Destroy(Explosion, 0.5f);
        Destroy(this.gameObject, 0.6f);
    }

    public void SetPutter(PutObject po)
    {
        this.po = po;
    }
    private IEnumerator DelayMethod(float waitTime, Action action)
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }

    public void SetColorRed()
    {
        GetComponent<Renderer>().material.color = beforeExplosionMaterial.color;
    }
}
