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
    private GameObject shotBullet;
    private GameObject shooterTank; //発射した戦車
    private bool shooterHitAble = false; //発射した戦車自身に当たるかどうか
    private float countTime = 0f;

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

        sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    private void Update()
    {
        if (!this.shooterHitAble)
        {
            countTime += Time.deltaTime;
            if(countTime > 0.5f)
            {
                this.shooterHitAble = true;
            }
        }
    }
    private void OnCollisionEnter(Collision col)
    {

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
                if(!shooterHitAble && shooterTank.GetInstanceID() == col.gameObject.GetInstanceID())
                {
                    Debug.Log("発射直後の自分の弾に当たろうとした");
                }
                else
                {
                    //singlemission
                    if (MainGameController.gameNumber == 1)
                    {
                        smm.EnemyDestroy(col.gameObject.name);
                    }

                    es = GameObject.Find(col.gameObject.transform.root.gameObject.name).GetComponent<EnemyStatus>();
                    sm.AddScore(es);
                    SEManager.PlayDestroyTankSound();
                    Destroy(col.gameObject);
                    DestroyBullet(this.gameObject);
                }
            }
            if (col.gameObject.CompareTag("Player"))
            {
                if (!shooterHitAble && shooterTank.GetInstanceID() == col.gameObject.GetInstanceID())
                {
                    Debug.Log("発射直後の自分の弾に当たろうとした");
                }
                else
                {
                    //singlemission
                    if (MainGameController.gameNumber == 1)
                    {
                        smm.PlayerDestroy();
                    }
                    else if (MainGameController.gameNumber == 2)
                    {
                        ssm.PlayerDestroy();
                    }
                    SEManager.PlayDestroyTankSound();
                    col.gameObject.SetActive(false);
                    this.gameObject.SetActive(false);
                }
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
                this.shotBullet.GetComponent<ShotBullet>().DestroyBullet();
            }
            else if (bullet.CompareTag("EnemyBullet"))
            {
                this.shotBullet.GetComponent<EnemyShotManager>().DestroyBullet();
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
        this.shotBullet = shooter;
    }
    public GameObject GetShooter()
    {
        return this.shotBullet;
    }
    public void SetShooterTank(GameObject shooterTank)
    {
        this.shooterTank = shooterTank;
    }
}
