using System.Collections;
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

    public int haveSkillNum; //持ってるスキルの数
    public float[] skillInterval;
    public GameObject[] skillIconPrefab;
    public int[] skillNum; //スキル番号
    private Image[] ableSkillIcon = new Image[2];

    private int skillKindNum = 10; //スキルの種類数

    public GameObject specialBulletPrefab;
    private float[] countTime = new float[2];
    private TankMovement tm;
    private ShotBullet sb;
    private PutObject po;
    private int gamePadNum;

    private Action[] sFunc; //スキルの関数を格納
    public void SkillSet()
    {
        sFunc = new Action[skillKindNum];
        sFunc[0] = UseSkillMoveSpeedUp;
        sFunc[1] = UseSkillShotSpeedUp;
        sFunc[2] = UseSkillShotSpecialBullet;
        sFunc[3] = UseSkillPutShooter;
        sFunc[4] = UseSkillPutProtectDome;
        sFunc[5] = UseSkillPutRemoteBomb;
        sFunc[6] = UseSkillPutBomberMan;
        sFunc[7] = UseSkillPutLaser;
        sFunc[8] = UseSkillPutWarp;
        sFunc[9] = UseSkillPutSwitchGate;
    }

    public void SkillIconSet()
    {
        GameObject skillIconCanvas = GameObject.Find("SkillIconCanvas");
        if(haveSkillNum > 0)
        {
            GameObject skill1Icon = Instantiate(skillIconPrefab[0], new Vector3(-230f, 60f, 0f), Quaternion.identity, skillIconCanvas.transform);
            ableSkillIcon[0] = skill1Icon.transform.Find("AbleIcon").gameObject.GetComponent<Image>();
            ableSkillIcon[0].fillAmount = 0f;
        }
        if(haveSkillNum > 1)
        {
            GameObject skill2Icon = Instantiate(skillIconPrefab[1], new Vector3(-230f, -20f, 0f), Quaternion.identity, skillIconCanvas.transform);
            ableSkillIcon[1] = skill2Icon.transform.Find("AbleIcon").gameObject.GetComponent<Image>();
            ableSkillIcon[1].fillAmount = 0f;
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        tm = GetComponent<TankMovement>();
        sb = this.transform.Find("Cannon/ShotBullet").gameObject.GetComponent<ShotBullet>();
        po = this.transform.Find("Cannon").gameObject.GetComponent<PutObject>();
        gamePadNum = GetComponent<GamePadManager>().GetGamePadNum();
        countTime[0] = 0f;
        countTime[0] = 0f;
        SkillSet();
        SkillIconSet();
    }

    // Update is called once per frame
    void Update()
    {
        if(haveSkillNum > 0)
        {
            countTime[0] += Time.deltaTime;
            if (Input.GetButtonDown(GamePadManager.padSkill1[gamePadNum]) && countTime[0] >= skillInterval[0])
            {
                sFunc[skillNum[0]]();
                countTime[0] = 0f;
            }
        }
        if (haveSkillNum > 1)
        {
            countTime[1] += Time.deltaTime;
            if (Input.GetButtonDown(GamePadManager.padSkill2[gamePadNum]) && countTime[1] >= skillInterval[1])
            {
                sFunc[skillNum[1]]();
                countTime[1] = 0f;
            }
        }
        if (Input.GetButtonDown(GamePadManager.padFire2[gamePadNum]))
        {
            po.PutLandMinePrefab();
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
    public void UseSkillPutWarp()
    {
        po.PutWarpPrefab();
    }
    public void UseSkillPutSwitchGate()
    {
        po.PutSwitchGatePrefab();
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
        for(int i = 0; i < haveSkillNum; i++)
        {
            ableSkillIcon[i].fillAmount = SetFillAmount(countTime[i] / skillInterval[i]);
        }
    }
}
