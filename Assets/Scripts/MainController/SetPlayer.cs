using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayer : MonoBehaviour
{
    public GameObject[] playerTank = new GameObject[4];
    public Vector3 v;
    // Start is called before the first frame update
    void Start()
    {
        int select = MainGameController.GetPlayerSelectTankNumber();
        Instantiate(playerTank[select], v, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
