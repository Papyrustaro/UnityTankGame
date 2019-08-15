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
    public int[] skillNumber; //スキル番号
    private Image[] ableSkillIcon = new Image[2];
    private Sprite[] ableSkillSprite = new Sprite[2];
    private Sprite[] notAbleSkillSprite = new Sprite[2];
    private SkillIconData sid;

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
            GameObject skill1AbleIcon = skillIconCanvas.transform.Find("Skill1Icon/AbleIcon").gameObject;
            GameObject skill1NotAbleIcon = skillIconCanvas.transform.Find("Skill1Icon/NotAbleIcon").gameObject;
            skill1AbleIcon.SetActive(true);
            skill1NotAbleIcon.SetActive(true);
            sid = skillIconCanvas.GetComponent<SkillIconData>();
            ableSkillIcon[0] = skill1AbleIcon.GetComponent<Image>();

            skill1AbleIcon.GetComponent<Image>().sprite = sid.GetSkillAbleSprite(skillNumber[0]);
            skill1NotAbleIcon.GetComponent<Image>().sprite = sid.GetSkillNotAbleSprite(skillNumber[0]);

            ableSkillIcon[0].fillAmount = 0f;
        }
        if(haveSkillNum > 1)
        {
            GameObject skill2AbleIcon = skillIconCanvas.transform.Find("Skill2Icon/AbleIcon").gameObject;
            GameObject skill2NotAbleIcon = skillIconCanvas.transform.Find("Skill2Icon/NotAbleIcon").gameObject;
            skill2AbleIcon.SetActive(true);
            skill2NotAbleIcon.SetActive(true);
            ableSkillIcon[1] = skill2AbleIcon.GetComponent<Image>();

            skill2AbleIcon.GetComponent<Image>().sprite = sid.GetSkillAbleSprite(skillNumber[1]);
            skill2NotAbleIcon.GetComponent<Image>().sprite = sid.GetSkillNotAbleSprite(skillNumber[1]);

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
                sFunc[skillNumber[0]]();
                countTime[0] = 0f;
            }
        }
        if (haveSkillNum > 1)
        {
            countTime[1] += Time.deltaTime;
            if (Input.GetButtonDown(GamePadManager.padSkill2[gamePadNum]) && countTime[1] >= skillInterval[1])
            {
                sFunc[skillNumber[1]]();
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
