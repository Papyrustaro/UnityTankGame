using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class OptionManager : MonoBehaviour
{
    public GameObject confirmDeleteAllDataText;
    public GameObject yesDeleteAllDataButton;
    public GameObject noDeleteAllDataButton;
    public GameObject announceDeleteAllDataText;
    public GameObject deleteAllDataButton;

    public GameObject goTitleButton;
    public GameObject goMenuButton;

    public GameObject BGMVolumeButton;
    private Text BGMVolumeButtonText;

    private void Start()
    {
        BGMVolumeButtonText = BGMVolumeButton.transform.Find("Text").gameObject.GetComponent<Text>();

        switch (BGMManager.baseVolume)
        {
            case 1f:
                BGMVolumeButtonText.text = "サウンド:OFF";
                break;
            case 0.5f:
                BGMVolumeButtonText.text = "サウンド:ON(中)";
                break;
            case 0f:
                BGMVolumeButtonText.text = "サウンド:ON(小)";
                break;
            default:
                break;
        }

    }

    public void OnPressBGMFlag()
    {
        switch (BGMManager.baseVolume)
        {
            case 1f:
                BGMManager.baseVolume = 0f;
                BGMManager.SetVolume(1f);
                BGMVolumeButtonText.text = "サウンド:ON(小)";
                break;
            case 0.5f:
                BGMManager.baseVolume = 1f;
                BGMManager.SetVolume(1f);
                BGMVolumeButtonText.text = "サウンド:OFF";
                break;
            case 0f:
                BGMManager.baseVolume = 0.5f;
                BGMManager.SetVolume(1f);
                BGMVolumeButtonText.text = "サウンド:ON(中)";
                break;
            default:
                break;
        }
    }

    public void OnPressDeleteAllData()
    {
        deleteAllDataButton.SetActive(false);
        BGMVolumeButton.SetActive(false);
        goMenuButton.SetActive(false);
        goTitleButton.SetActive(false);
        yesDeleteAllDataButton.SetActive(true);
        noDeleteAllDataButton.SetActive(true);
        confirmDeleteAllDataText.SetActive(true);
        noDeleteAllDataButton.GetComponent<Button>().Select();
    }
    public void OnPressYesDeleteAllData()
    {
        PlayerPrefs.DeleteAll();
        yesDeleteAllDataButton.SetActive(false);
        noDeleteAllDataButton.SetActive(false);
        Debug.Log("全データを消去しました。");
        announceDeleteAllDataText.SetActive(true);
        BGMVolumeButton.SetActive(true);
        goMenuButton.SetActive(true);
        goTitleButton.SetActive(true);
        deleteAllDataButton.SetActive(true);
        confirmDeleteAllDataText.SetActive(false);

        StartCoroutine(DelayMethod(2f, () =>
        {
            announceDeleteAllDataText.SetActive(false);
        }));
    }
    public void OnPressNoDeleteAllData()
    {
        yesDeleteAllDataButton.SetActive(false);
        noDeleteAllDataButton.SetActive(false);
        confirmDeleteAllDataText.SetActive(false);
        goMenuButton.SetActive(true);
        goTitleButton.SetActive(true);
        BGMVolumeButton.SetActive(true);
        deleteAllDataButton.SetActive(true);
    }

    private IEnumerator DelayMethod(float waitTime, Action action)
    {
        yield return new WaitForSecondsRealtime(waitTime);
        action();
    }
}
