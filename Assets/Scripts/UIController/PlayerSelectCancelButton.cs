using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelectCancelButton : MonoBehaviour
{
    private int selectTankNum;
    private GameObject tankButtonPanel;
    private GameObject selectTankText;
    private GameObject startButton;
    private GameObject cancelButton;
    private PlayerSelectUI psui;

    private void Awake()
    {
        tankButtonPanel = transform.parent.transform.Find("TankButtons").gameObject;
        selectTankText = transform.parent.transform.Find("SelectTankText").gameObject;
        startButton = transform.parent.transform.Find("StartButton").gameObject;
        cancelButton = transform.parent.transform.Find("CancelButton").gameObject;
        psui = transform.parent.gameObject.GetComponent<PlayerSelectUI>();
    }
    public void OnPress()
    {
        SEManager.PlaySubmitSound();
        psui.PressCancelButton();
    }
    public void SetSelectTankNum(int selectTankNum)
    {
        this.selectTankNum = selectTankNum;
    }
}
