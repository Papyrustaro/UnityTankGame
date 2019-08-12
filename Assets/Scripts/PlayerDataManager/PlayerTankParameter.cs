using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTankParameter : MonoBehaviour
{
    public float moveSpeedMagni = 1f;
    public float shotSpeedMagni = 1f;
    public int shotAbleBulletNum = 5;
    public int putAbleLandMineNum = 2;
    public int addScore = 0;
    public int haveSkillNum = 0;
    public int lifeNum = 5;
    public string description;

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
}
