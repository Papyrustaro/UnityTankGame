using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyHitPlayer : MonoBehaviour
{
    private SingleMissionManager smm;
    private SingleSurvivalManager ssm;

    private void Awake()
    {
        if(MainGameController.gameNumber == 1)
        {
            smm = GameObject.Find("SingleMissionManager").GetComponent<SingleMissionManager>();
        }else if(MainGameController.gameNumber == 2)
        {
            ssm = GameObject.Find("SingleSurvivalManager").GetComponent<SingleSurvivalManager>();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.gameObject.CompareTag("Player"))
        {
            //singlemission
            if (MainGameController.gameNumber == 1)
            {
                smm.PlayerDestroy();
            }
            else if (MainGameController.gameNumber == 2)
            {
                ssm.PlayerDestroy();
            }

            other.transform.root.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
}
