using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTankParameter : MonoBehaviour
{
    public float moveSpeedMagni = 1f;
    public float shotSpeedMagni = 1f;
    public int shotAbleBulletNum = 5;
    public int putAbleLandMineNum = 2;
    public int lifeNum = 5;
    public string description;
    public string releaseCondition;
    public string announce;
    public int tankNumber;

    private void Start()
    {
        try
        {
            PutObject po = this.transform.Find("Cannon").gameObject.GetComponent<PutObject>();
            po.SetPutAbleLandMineNum(this.putAbleLandMineNum);
        }catch(System.Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    public int GetPutAbleLandMineNum()
    {
        return this.putAbleLandMineNum;
    }
    public float GetMoveSpeedMagni()
    {
        return this.moveSpeedMagni;
    }
    public float GetShotSpeedMagni()
    {
        return this.shotSpeedMagni;
    }
    public int GetShotAbleBulletNum()
    {
        return this.shotAbleBulletNum;
    }
    public int GetLifeNum()
    {
        return this.lifeNum;
    }
    public string GetDescription()
    {
        return this.description;
    }
    public int GetTankNumber()
    {
        return this.tankNumber;
    }
    public string GetAnnounce()
    {
        return this.announce;
    }
    public string GetReleaseCondition()
    {
        return this.releaseCondition;
    }
}
