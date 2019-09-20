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
    private GameObject shooter; //発射した戦車

    //シングルミッション
    private SingleMissionManager smm;
    private SingleSurvivalManager ssm;
    private void Start()
    {
        //シングルミッション
        if(MainGameController.gameNumber == 1)
        {
            smm = GameObject.Find("SingleMissionManager").GetComponent<SingleMissionManager>();
        }else if(MainGameController.gameNumber == 2)
        {
            ssm = GameObject.Find("SingleSurvivalManager").GetComponent<SingleSurvivalManager>();
        }
    }
    private void OnCollisionEnter(Collision col)
    {
        sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();

        if (hit == false)
        {
            hit = true;
            if (col.gameObject.CompareTag("Stage") || col.gameObject.CompareTag("Wall"))
            {
                bounceAble--;
                if (bounceAble < 0)
                {
                    DestroyBullet(this.gameObject);
                }
            }
            if (col.gameObject.CompareTag("DestroyableObject"))
            {
                DestroyByAttack dos = col.gameObject.GetComponent<DestroyByAttack>();
                dos.hitBullet();
                DestroyBullet(this.gameObject);
            }
            if(col.gameObject.CompareTag("Bullet") || col.gameObject.CompareTag("EnemyBullet") || col.gameObject.CompareTag("SpecialBullet"))
            {
                DestroyBullet(this.gameObject);
            }
            if (col.gameObject.CompareTag("Enemy"))
            {
                //singlemission
                if(MainGameController.gameNumber == 1)
                {
                    smm.EnemyDestroy(col.gameObject.name);
                }

                es = GameObject.Find(col.gameObject.transform.root.gameObject.name).GetComponent<EnemyStatus>();
                sm.AddScore(es);
                Destroy(col.gameObject);
                DestroyBullet(this.gameObject);
            }
            if (col.gameObject.CompareTag("Player"))
            {
                //singlemission
                if(MainGameController.gameNumber == 1)
                {
                    smm.PlayerDestroy();
                }else if(MainGameController.gameNumber == 2)
                {
                    ssm.PlayerDestroy();
                }

                col.gameObject.SetActive(false);
                this.gameObject.SetActive(false);
            }
        }
    }


    public void DestroyBullet(GameObject bullet)
    {
        //if (bullet.CompareTag("Bullet")) //プレイヤーの弾だったら
        try
        {
            if (bullet.name == "Bullet(Clone)")
            {
                this.shooter.GetComponent<ShotBullet>().DestroyBullet();
            }
            else if (bullet.CompareTag("EnemyBullet"))
            {
                this.shooter.GetComponent<EnemyShotManager>().DestroyBullet();
            }
        }
        catch (MissingReferenceException)
        {

        }
        Destroy(bullet);
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
    public void SetShooter(GameObject shooter)
    {
        this.shooter = shooter;
    }
    public GameObject GetShooter()
    {
        return this.shooter;
    }
}
