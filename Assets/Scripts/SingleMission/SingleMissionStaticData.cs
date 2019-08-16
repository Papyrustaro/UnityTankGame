using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleMissionStaticData : MonoBehaviour
{
    public static int selectTankNumber;
    public static int playerScore = 0;
    public static int playerLife = 3;
    public static int enemyNumSetStage = 3;
    public static bool[] enemyIsDeath;
    public static int remainEnemyNum = 3;
    public static int missionNumber = 2;
    public static bool loadNewStage = true;
}
