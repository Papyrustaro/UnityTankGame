using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleMissionStaticData : MonoBehaviour
{
    public static GameObject selectTank;
    public static int playerScore = 0;
    public static int playerLife = 3;
    public static int enemyNumSetStage;
    public static bool[] enemyIsDeath;
    public static int remainEnemyNum;
    public static int missionNumber = 0;
    public static bool loadNewStage = true;
}
