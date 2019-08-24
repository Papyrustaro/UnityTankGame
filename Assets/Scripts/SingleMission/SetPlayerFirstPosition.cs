﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerFirstPosition : MonoBehaviour
{
    public GameObject[] tankPrefab = new GameObject[21];
    private void Awake()
    {
        if(MainGameController.gameNumber == 1)
        {
            Instantiate(tankPrefab[SingleMissionStaticData.selectTankNumber], this.transform.position, this.transform.rotation);
        }else if(MainGameController.gameNumber == 2)
        {
            Instantiate(tankPrefab[SurvivalManager.selectTankNumber], this.transform.position, this.transform.rotation);
        }
    }
}
