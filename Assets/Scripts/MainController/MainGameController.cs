using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameController : MonoBehaviour
{
    public static int gameNumber = 0; //1.singleMission, 2.survival
    private static int playerSelectTankNumber;
    public static int trajectoryMode = 1; //0.弾道表示なし 1.弾道表示あり 2.targetによる操作
    public static void SetPlayerSelectTankNumber(int n)
    {
        MainGameController.playerSelectTankNumber = n;
    }
    public static int GetPlayerSelectTankNumber()
    {
        return MainGameController.playerSelectTankNumber;
    }
}
