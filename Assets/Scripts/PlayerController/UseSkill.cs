using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UseSkill : MonoBehaviour
{
    public float moveSpeedUpMagni = 1.5f; //何倍のスピードになるか
    public float moveSpeedUpTime = 2f; //スキル適用時間
    public float moveSpeedUpInterval = 10f; //スキルを使用してから次使えるまで
    //private bool isSpeedUp = false; //インターバル長いためいらない

    public float shotSpeedUpMagni = 1.5f;
    public float shotSpeedUpTime = 2f;
    public float shotSpeedUpInterval = 10f;

    public GameObject specialBulletPrefab;
    public float shotSpecialBulletInterval = 20f;

    private float countTime;
    private TankMovement tm;
    private ShotBullet sb;

    // Start is called before the first frame update
    void Start()
    {
        tm = GetComponent<TankMovement>();
        sb = GameObject.Find("Player/Cannon/ShotBullet").GetComponent<ShotBullet>();
        countTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        countTime += Time.deltaTime;
        if (Input.GetButtonDown("Skill1") && countTime >= moveSpeedUpInterval)
        {
            countTime = 0f;
            useSkillMoveSpeedUp();
        }
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

    private IEnumerator DelayMethod(float waitTime, Action action)
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }
}
