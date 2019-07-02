﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class UseSkill : MonoBehaviour
{
    private float moveSpeedUpMagni = 1.5f; //何倍のスピードになるか
    private float moveSpeedUpTime = 2f; //スキル適用時間
    private float shotSpeedUpMagni = 2f;
    private float shotSpeedUpTime = 2f;

    public float skill1Interval = 5f;
    public float skill2Interval = 5f;
    public GameObject skill1IconPrefab;
    public GameObject skill2IconPrefab;
    public int skill1Num; //スキル番号
    public int skill2Num;
    private int skillKindNum = 8; //スキルの種類数
    private Image ableSkill1Icon;
    private Image ableSkill2Icon;

    public GameObject specialBulletPrefab;
    private float countTime1;
    private float countTime2;
    private TankMovement tm;
    private ShotBullet sb;
    private PutObject po;

    //private delegate void skillFunction();
    struct skillArray
    {
        public Action sFunc;
    }
    private skillArray[] SA;

    public void SkillSet()
    {
        SA = new skillArray[skillKindNum];
        SA[0].sFunc = UseSkillMoveSpeedUp;
        SA[1].sFunc = UseSkillShotSpeedUp;
        SA[2].sFunc = UseSkillShotSpecialBullet;
        SA[3].sFunc = UseSkillPutShooter;
        SA[4].sFunc = UseSkillPutProtectDome;
        SA[5].sFunc = UseSkillPutRemoteBomb;
        SA[6].sFunc = UseSkillPutBomberMan;
        SA[7].sFunc = UseSkillPutLaser;
    }

    public void SkillIconSet()
    {
        GameObject skillIconCanvas = GameObject.Find("SkillIconCanvas");
        GameObject skill1Icon = (GameObject)Instantiate(skill1IconPrefab, new Vector3(-230f, 60f, 0f), Quaternion.identity, skillIconCanvas.transform);
        GameObject skill2Icon = (GameObject)Instantiate(skill2IconPrefab, new Vector3(-230f, -20f, 0f), Quaternion.identity, skillIconCanvas.transform);
        ableSkill1Icon = skill1Icon.transform.Find("AbleIcon").gameObject.GetComponent<Image>();
        ableSkill2Icon = skill2Icon.transform.Find("AbleIcon").gameObject.GetComponent<Image>();
        ableSkill1Icon.fillAmount = 0f;
        ableSkill2Icon.fillAmount = 0f;
    }
    // Start is called before the first frame update
    void Start()
    {
        tm = GetComponent<TankMovement>();
        sb = this.transform.Find("Cannon/ShotBullet").gameObject.GetComponent<ShotBullet>();
        po = this.transform.Find("Cannon").gameObject.GetComponent<PutObject>();
        countTime1 = 0f;
        countTime2 = 0f;
        SkillSet();
        SkillIconSet();
    }

    // Update is called once per frame
    void Update()
    {
        countTime1 += Time.deltaTime;
        countTime2 += Time.deltaTime;
        if(Input.GetButtonDown("Skill1") && countTime1 >= skill1Interval)
        {
            SA[skill1Num].sFunc();
            countTime1 = 0f;
        }
        if(Input.GetButtonDown("Skill2") && countTime2 >= skill2Interval)
        {
            SA[skill2Num].sFunc();
            countTime2 = 0f;
        }
        SetFillAmount();
    }

    public void UseSkillMoveSpeedUp()
    {
        tm.setMoveSpeed(moveSpeedUpMagni);
        StartCoroutine(DelayMethod(moveSpeedUpTime, () =>
        {
            tm.setMoveSpeed(1 / moveSpeedUpMagni);
        }));
    }

    public void UseSkillShotSpeedUp()
    {
        sb.setShotSpeed(shotSpeedUpMagni);
        StartCoroutine(DelayMethod(shotSpeedUpTime, () =>
        {
            sb.setShotSpeed(1 / shotSpeedUpMagni);
        }));
    }

    public void UseSkillShotSpecialBullet()
    {
        sb.Shot(specialBulletPrefab);
    }

    //砲台を設置するスキル
    public void UseSkillPutShooter()
    {
        po.PutBatteryPrefab();
    }
    public void UseSkillPutProtectDome()
    {
        po.PutProtectDomePrefab();
    }
    public void UseSkillPutRemoteBomb()
    {
        po.PutRemoteBombPrefab();
    }
    public void UseSkillPutBomberMan()
    {
        po.PutBombermanPrefab();
    }
    public void UseSkillPutLaser()
    {
        po.PutLaserPrefab();
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
        ableSkill1Icon.fillAmount = SetFillAmount(countTime1 / skill1Interval);
        ableSkill2Icon.fillAmount = SetFillAmount(countTime2 / skill2Interval);
    }
}
