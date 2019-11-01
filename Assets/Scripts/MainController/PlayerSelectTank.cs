using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerSelectTank : MonoBehaviour
{
    public Button[] playerSelectTank = new Button[4];
    // Start is called before the first frame update
    void Start()
    {
        playerSelectTank[0].Select();
    }
    public void SelectTankNum(int n)
    {
        MainGameController.SetPlayerSelectTankNumber(n);
        SceneManager.LoadScene("SingleMission1");
    }
}
