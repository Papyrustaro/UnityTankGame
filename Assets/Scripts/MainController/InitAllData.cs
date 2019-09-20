using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitAllData : MonoBehaviour
{
    public static void InitData()
    {
        Debug.Log("一時データを初期化しました");

        SingleMissionStaticData.playerScore = 0;
        SingleMissionStaticData.playerLife = 3;
        SingleMissionStaticData.countTime = 0f;
        SingleMissionStaticData.missionNumber = 0;
        SingleMissionStaticData.loadNewStage = true;

        SingleSurvivalStaticData.playerScore = 0;
    }
}
