﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameController : MonoBehaviour
{
    public static int gameNumber = 1; //1.singleMission, 2.survival, 3.VS
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
