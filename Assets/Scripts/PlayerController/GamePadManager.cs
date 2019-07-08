using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePadManager : MonoBehaviour
{
    public int gamePadNum;

    public static readonly string[] padHorizontal = { "Horizontal", "Horizontal_1" };
    public static readonly string[] padVertical = { "Vertical", "Vertical_1" };
    public static readonly string[] padCannonHorizontal = { "CannonHorizontal", "CannonHorizontal_1" };
    public static readonly string[] padCannonVertical = { "CannonVertical", "CannonVertical_1" };
    public static readonly string[] padFire1 = { "Fire1", "Fire1_1" };
    public static readonly string[] padFire2 = { "Fire2", "Fire2_1" };
    public static readonly string[] padSkill1 = { "Skill1", "Skill1_1" };
    public static readonly string[] padSkill2 = { "Skill2", "Skill2_1" };

    public int GetGamePadNum()
    {
        return gamePadNum;
    }
}
