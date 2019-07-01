using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameController : MonoBehaviour
{
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
