using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerSelectUI : MonoBehaviour
{
    public Button[] buttons = new Button[21];
    public int selectTankNum;
    public GameObject parameterCanvas;

    private GameObject tankButtonPanel;
    private GameObject selectTankText;
    private GameObject startButton;
    private GameObject cancelButton;

    private void Awake()
    {
        tankButtonPanel = transform.Find("TankButtons").gameObject;
        selectTankText = transform.Find("SelectTankText").gameObject;
        startButton = transform.Find("StartButton").gameObject;
        cancelButton = transform.Find("CancelButton").gameObject;

        startButton.SetActive(false);
        cancelButton.SetActive(false);

        if(MainGameController.gameNumber != 1)
        {
            parameterCanvas.transform.Find("ParameterPanel/Life").gameObject.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        buttons[0].Select();
    }

    public void selectButton(int n)
    {
        if(0 <= n && n < 21)
        {
            buttons[n].Select();
        }
    }

    public void SelectButton(int buttonNum)
    {
        buttons[buttonNum].Select();
    }
    public void SelectButton()
    {
        buttons[this.selectTankNum].Select();
    }
    public void PressCancelButton()
    {
        selectTankText.SetActive(true);
        startButton.SetActive(false);
        tankButtonPanel.SetActive(true);
        SelectButton();
        cancelButton.SetActive(false);
    }

    public void SetSelectTankNum(int n)
    {
        this.selectTankNum = n;
    }
    public int GetSelectTankNum()
    {
        return this.selectTankNum;
    }
    public void PressTankButton()
    {
        selectTankText.SetActive(false);
        startButton.SetActive(true);
        cancelButton.SetActive(true);
        startButton.GetComponent<Button>().Select();
        tankButtonPanel.SetActive(false);
    }
    public bool IsSelectTank()
    {
        return startButton.activeSelf;
    }
}
