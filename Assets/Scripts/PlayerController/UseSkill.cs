using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class UseSkill : MonoBehaviour
{
    private float moveSpeedUpMagni = 1.5f; //何倍のスピードになるか
    private float moveSpeedUpTime = 2f; //スキル適用時間
    public float moveSpeedUpInterval = 10f; //スキルを使用してから次使えるまで
    //private bool isSpeedUp = false; //インターバル長いためいらない
    public Image moveSpeedUpIcon;

    private float shotSpeedUpMagni = 1.5f;
    private float shotSpeedUpTime = 2f;
    public float shotSpeedUpInterval = 10f;
    public Image shotSpeedUpIcon;

    public GameObject specialBulletPrefab;
    public float shotSpecialBulletInterval = 20f;
    public Image shotSpecialBulletIcon;

    public float putBatteryInterval = 1f; //本当は30fくらい
    public float putProtectDomeInterval = 1f; //本当は30fくらい
    public float putRemoteBombInterval = 1f;

    private float countTime;
    private TankMovement tm;
    private ShotBullet sb;
    private PutObject po;

    // Start is called before the first frame update
    void Start()
    {
        tm = GetComponent<TankMovement>();
        sb = GameObject.Find("Player/Cannon/ShotBullet").GetComponent<ShotBullet>();
        po = GameObject.Find("Player/Cannon").GetComponent<PutObject>();
        countTime = 0f;
        moveSpeedUpIcon.fillAmount = 0f;
        shotSpeedUpIcon.fillAmount = 0f;
        shotSpecialBulletIcon.fillAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        countTime += Time.deltaTime;
        /*if (Input.GetButtonDown("Skill1") && countTime >= moveSpeedUpInterval)
        {
            countTime = 0f;
            useSkillMoveSpeedUp();
        }*/
        if(Input.GetButtonDown("Skill2") && countTime >= shotSpeedUpInterval)
        {
            countTime = 0f;
            useSkillShotSpeedUp();
        }
        if (Input.GetButtonDown("Fire2") && countTime >= shotSpecialBulletInterval)
        {
            countTime = 0f;
            sb.Shot(specialBulletPrefab);
        }
        /*if(Input.GetButtonDown("Skill1") && countTime >= putBatteryInterval)
        {
            countTime = 0f;
            useSkillPutBattery();
        }*/
        /*if(Input.GetButtonDown("Skill1") && countTime >= putProtectDomeInterval)
        {
            countTime = 0f;
            useSkillPutProtectDome();
        }*/
        if (Input.GetButtonDown("Skill1") && countTime >= putRemoteBombInterval)
        {
            countTime = 0f;
            useSkillPutRemoteBomb();
        }
        SetFillAmount();
    }

    public void useSkillMoveSpeedUp()
    {
        tm.setMoveSpeed(moveSpeedUpMagni);
        StartCoroutine(DelayMethod(moveSpeedUpTime, () =>
        {
            tm.setMoveSpeed(1 / moveSpeedUpMagni);
        }));
    }

    public void useSkillShotSpeedUp()
    {
        sb.setShotSpeed(shotSpeedUpMagni);
        StartCoroutine(DelayMethod(shotSpeedUpTime, () =>
        {
            sb.setShotSpeed(1 / shotSpeedUpMagni);
        }));
    }

    //砲台を設置するスキル
    public void useSkillPutBattery()
    {
        po.PutBatteryPrefab();
    }
    public void useSkillPutProtectDome()
    {
        po.PutProtectDomePrefab();
    }
    public void useSkillPutRemoteBomb()
    {
        po.PutRemoteBombPrefab();
    }

    private IEnumerator DelayMethod(float waitTime, Action action)
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }

    private float SetFillAmount(float value)
    {
        if(value >= 1f)
        {
            return 1f;
        }
        else
        {
            return value;
        }
    }
    private void SetFillAmount()
    {
        moveSpeedUpIcon.fillAmount = SetFillAmount(countTime / moveSpeedUpInterval);
        shotSpeedUpIcon.fillAmount = SetFillAmount(countTime / shotSpeedUpInterval);
        shotSpecialBulletIcon.fillAmount = SetFillAmount(countTime / shotSpecialBulletInterval);
    }
}
