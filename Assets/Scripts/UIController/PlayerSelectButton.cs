using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerSelectButton : MonoBehaviour
{
    public GameObject parameterPanel;
    public GameObject selectTankObject; //prefabではなく、hierarchyのplayertank内のobject
    private PlayerTankParameter ptp;
    private PlayerSelectUI psui;

    private Text lifeNumText;
    private Text moveSpeedText;
    private Text shotSpeedText;
    private Text bulletNumText;
    private Text descriptionText;
    private Text announceText;
    private Text releaseConditionText;

    private string lifeNum;
    private string moveSpeed;
    private string shotSpeed;
    private string bulletNum;
    private string description;
    private string announce = "";
    private string releaseCondition = "";

    private void Awake()
    {
        ptp = selectTankObject.GetComponent<PlayerTankParameter>();
        psui = transform.parent.transform.parent.gameObject.GetComponent<PlayerSelectUI>();
        lifeNumText = parameterPanel.transform.Find("Life").gameObject.GetComponent<Text>();
        moveSpeedText = parameterPanel.transform.Find("MoveSpeed").gameObject.GetComponent<Text>();
        shotSpeedText = parameterPanel.transform.Find("ShotSpeed").gameObject.GetComponent<Text>();
        bulletNumText = parameterPanel.transform.Find("BulletNum").gameObject.GetComponent<Text>();
        descriptionText = parameterPanel.transform.Find("Description").gameObject.GetComponent<Text>();
        announceText = parameterPanel.transform.Find("Announce").gameObject.GetComponent<Text>();
        releaseConditionText = parameterPanel.transform.Find("ReleaseCondition").gameObject.GetComponent<Text>();

        int moveS = (int)(ptp.GetMoveSpeedMagni() * 100);
        int shotS = (int)(ptp.GetShotSpeedMagni() * 100);
        if (moveS % 5 != 0) moveS++;
        if (shotS % 5 != 0) shotS++;

        lifeNum = "ライフ: " + ptp.GetLifeNum();
        moveSpeed = "移動速度: " + moveS;
        shotSpeed = "発射速度: " + shotS;
        bulletNum = "装弾数: " + ptp.GetShotAbleBulletNum();
        description = "特徴: " + ptp.GetDescription();
        if(ptp.GetTankNumber() >= 21 && PlayerPrefs.GetInt("UseableTank" + ptp.GetTankNumber(), 0) == 0)
        {
            releaseCondition = ptp.GetReleaseCondition();
        }else if(MainGameController.gameNumber == 2)
        {
            announce = ptp.GetAnnounce();
        }
    }
    public void OnSelect()
    {
        SEManager.PlaySelectButtonSound();
        lifeNumText.text = lifeNum;
        moveSpeedText.text = moveSpeed;
        shotSpeedText.text = shotSpeed;
        bulletNumText.text = bulletNum;
        descriptionText.text = description;
        announceText.text = announce;
        releaseConditionText.text = releaseCondition;
        selectTankObject.SetActive(true);
    }
    public void OnDeselect()
    {
        if (!psui.IsSelectTank())
        {
            try
            {
                selectTankObject.SetActive(false);
                selectTankObject.transform.position = new Vector3(3f, 0f, 0f);
            }catch(Exception e)
            {
                Debug.Log(e);
            }
        }
    }

    public void OnPress()
    {
        if(ptp.GetTankNumber() >= 21)
        {
            //戦車がまだ解放されていなかったら選べない
            if (PlayerPrefs.GetInt("UseableTank" + ptp.GetTankNumber(), 0) != 1)
            {
                SEManager.PlaySound(SEManager.cannotSound);
                return;
            }
        }
        SEManager.PlaySubmitSound();
        if(MainGameController.gameNumber == 1)
        {
            SingleMissionStaticData.selectTankNumber = ptp.GetTankNumber();
            SingleMissionStaticData.playerLife = ptp.GetLifeNum();
        }
        else if(MainGameController.gameNumber == 2)
        {
            SingleSurvivalStaticData.selectTankNumber = ptp.GetTankNumber();
        }
        psui.SetSelectTankNum(ptp.GetTankNumber());
        psui.PressTankButton();
    }
}
