using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerSelectUI : MonoBehaviour
{
    public Button[] buttons = new Button[21];
    public GameObject[] selectTank = new GameObject[21];


    // Start is called before the first frame update
    void Start()
    {
        buttons[0].Select();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
