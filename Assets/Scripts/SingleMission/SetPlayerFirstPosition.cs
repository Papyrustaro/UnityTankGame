using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerFirstPosition : MonoBehaviour
{

    public GameObject[] tankPrefab = new GameObject[26];
    private void Awake()
    {
        if(MainGameController.gameNumber == 1)
        {
            Instantiate(tankPrefab[SingleMissionStaticData.selectTankNumber], this.transform.position, this.transform.rotation);
        }else if(MainGameController.gameNumber == 2)
        {
            Instantiate(tankPrefab[SingleSurvivalStaticData.selectTankNumber], this.transform.position, this.transform.rotation);
        }
    }
}
