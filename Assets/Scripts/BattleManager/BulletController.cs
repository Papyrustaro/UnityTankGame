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
        countTime += Time.deltaTime;
        if (!this.shooterHitAble)
        {
            if (countTime > 0.5f)
            {
                this.shooterHitAble = true;
            }
        }else if(countTime > 1f) //1秒ごとに発射戦車が生きてるか確認。いないなら10秒後消滅(壁に当たらない遅くなった弾を考慮)
        {
            try
            {
                if(shooterTank == null)
                {
                    StartCoroutine(DelayMethod(10f, () =>
                    {
                        SEManager.PlayDestroyBulletSound();
                        Destroy(this.gameObject);
                    }));
                }
            }catch(Exception)
            {
                SEManager.PlayDestroyBulletSound();
                Destroy(this.gameObject);
            }
            countTime = 0f;
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
                else
                {
                    SEManager.PlayBounceBulletSound();
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
                //Debug.Log(col.gameObject);
                try
                {
                    if (!shooterHitAble && shooterTank.GetInstanceID() == col.gameObject.GetInstanceID())
                    {
                        Debug.Log("発射直後の自分の弾に当たろうとした");
                    }
                    else
                    {
                        this.DestroyEnemy(col.gameObject);
                    }
                }
                catch(NullReferenceException e)
                {
                    Debug.Log(e);
                }
            }
            if (col.gameObject.CompareTag("Player"))
            {
                try
                {
                    if (!shooterHitAble && shooterTank.GetInstanceID() == col.gameObject.GetInstanceID())
                    {
                        Debug.Log("発射直後の自分の弾に当たろうとした");
                    }
                    else
                    {
                        this.PlayerDestroy(col.gameObject);
                    }
                }
                catch(NullReferenceException e)
                {
                    Debug.Log(e);
                }
            }
        }
    }


    public void DestroyBullet(GameObject bullet)
    {
        try
        {
            if (shooterTank == null)
            {
                SEManager.PlayDestroyBulletSound();
                Destroy(this.gameObject);
            }
        }
        catch (Exception e)
        {
            Debug.Log(e);
            SEManager.PlayDestroyBulletSound();
            Destroy(this.gameObject);
        }
        try
        {
            if (bullet.name == "Bullet(Clone)")
            {
                this.shotBullet.GetComponent<ShotBullet>().DestroyBullet();
            }
            else if (bullet.CompareTag("EnemyBullet"))
            {
                this.shotBullet.GetComponent<EnemyShotManager>().DestroyBullet();
            }else if (bullet.name == "Bullet3(Clone)")
            {
                if(MainGameController.gameNumber == 1 && SingleMissionStaticData.selectTankNumber == 22)
                {
                    this.shotBullet.GetComponent<ShotBullet>().DestroyBullet();
                }
                else if(MainGameController.gameNumber == 2 && SingleSurvivalStaticData.selectTankNumber == 22)
                {
                    this.shotBullet.GetComponent<ShotBullet>().DestroyBullet();
                }
            }
        }
        catch (MissingReferenceException)
        {
            SEManager.PlayDestroyBulletSound();
            Destroy(this.gameObject);
        }
        SEManager.PlayDestroyBulletSound();
        Destroy(this.gameObject);
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

    private bool DestroyEnemy(GameObject enemy)
    {
        //IOManager.WriteFile("DestroyEnemy()が呼ばれた");
        TankStatus ts = enemy.GetComponent<TankStatus>();
        //IOManager.WriteFile(enemy.name + ": " + ts.GetIsAlive());
        if (ts.GetIsAlive())
        {
            ts.SetIsAlive(false);
            //singlemission
            if (MainGameController.gameNumber == 1)
            {
                smm.EnemyDestroy(enemy.name);
            }

            es = enemy.GetComponent<EnemyStatus>();
            sm.AddScore(es);
            SEManager.PlayDestroyTankSound();
            EffectManager.ShowBombEffect(enemy.transform.position);
            Destroy(enemy.gameObject);
            DestroyBullet(this.gameObject);
            return true;
        }
        return false;
    }

    private bool PlayerDestroy(GameObject player)
    {
        TankStatus ts = player.GetComponent<TankStatus>();
        if (ts.GetIsAlive())
        {
            ts.SetIsAlive(false);
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
            EffectManager.ShowBombEffect(player.transform.position);
            player.SetActive(false);
            this.gameObject.SetActive(false);
            return true;
        }
        return false;
    }
    private IEnumerator DelayMethod(float waitTime, Action action)
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }
}
