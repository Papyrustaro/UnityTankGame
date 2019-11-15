using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameController : MonoBehaviour
{
    public static int gameNumber = 0; //1.singleMission, 2.survival
    private static int playerSelectTankNumber;
    public static void SetPlayerSelectTankNumber(int n)
    {
        MainGameController.playerSelectTankNumber = n;
    }
    public static int GetPlayerSelectTankNumber()
    {
        return MainGameController.playerSelectTankNumber;
    }
}
