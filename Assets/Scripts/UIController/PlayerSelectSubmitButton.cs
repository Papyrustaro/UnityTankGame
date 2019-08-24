using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelectSubmitButton : MonoBehaviour
{
    public void OnPress()
    {
        //SingleMission
        if(MainGameController.gameNumber == 1)
        {
            SingleMissionStaticData.enemyIsDeath = new bool[1];
            SingleMissionStaticData.remainEnemyNum = 1;
            SingleMissionStaticData.loadNewStage = false;
            SceneManager.LoadScene("SingleMission0");
        }else if(MainGameController.gameNumber == 2) //survival
        {
            SceneManager.LoadScene("SurvivalStage1");
        }
    }
}
