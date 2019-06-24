using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class BulletController : MonoBehaviour
{
    public int bounceAble = 1;
    public float bulletSpeed;
    private bool hit = false;
    private ScoreManager sm;
    private EnemyStatus es;
    private ShotBullet sb;

    private void Start()
    {
        //sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();

        //1人プレイのときのみ有効
        //sb = GameObject.Find("Player/Cannon/ShotBullet").GetComponent<ShotBullet>();

    }
    private void OnCollisionEnter(Collision col)
    {
        sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();

        //1人プレイのときのみ有効
        sb = GameObject.Find("Player/Cannon/ShotBullet").GetComponent<ShotBullet>();

        if (hit == false)
        {
            hit = true;
            if (col.gameObject.CompareTag("Stage"))
            {
                bounceAble--;
                if (bounceAble < 0)
                {
                    if (this.gameObject.CompareTag("Bullet")) //プレイヤーの弾だったら
                    {
                        sb.DestroyBullet();
                    }
                    Destroy(this.gameObject);
                }
            }
            if(col.gameObject.CompareTag("Bullet") || col.gameObject.CompareTag("EnemyBullet"))
            {
                if (this.gameObject.CompareTag("Bullet")) //プレイヤーの弾だったら
                {
                    sb.DestroyBullet();
                }
                Destroy(col.gameObject);
                Destroy(this.gameObject);
            }
            if (col.gameObject.CompareTag("Enemy"))
            {
                es = GameObject.Find(col.gameObject.transform.root.gameObject.name).GetComponent<EnemyStatus>();
                sm.AddScore(es);
                Destroy(col.gameObject);
                if (this.gameObject.CompareTag("Bullet")) //プレイヤーの弾だったら
                {
                    sb.DestroyBullet();
                }
                Destroy(this.gameObject);
            }
            if (col.gameObject.CompareTag("Player"))
            {
                Destroy(sb);
                col.gameObject.SetActive(false);
                this.gameObject.SetActive(false);

                //GameOverSceneへ
                Invoke("GameOver", 0.5f);
            }
        }
    }

    private void OnCollisionExit(Collision col)
    {
        hit = false;
    }

    void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public float getBulletSpeed()
    {
        return bulletSpeed;
    }
}
