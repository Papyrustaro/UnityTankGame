using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleMissionStaticData : MonoBehaviour
{
    public static int selectTankNumber;
    public static int playerScore = 0;
    public static int playerLife = 3;
    public static float countTime = 0f;
    public static int enemyNumSetStage = 3;
    public static bool[] enemyIsDeath;
    public static int remainEnemyNum = 3;
    public static int missionNumber = 0;
    public static bool loadNewStage = true;
    public static bool pauseAble = false;
}
