using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutObject : MonoBehaviour
{
    private LookAtMouseCursor lamc;
    public GameObject batteryPrefab;

    // Start is called before the first frame update
    void Start()
    {
        lamc = GameObject.Find("Player/Cannon").GetComponent<LookAtMouseCursor>();
    }

    public void PutBatteryPrefab()
    {
        GameObject PutAbleBatteryPrefab = (GameObject)Instantiate(batteryPrefab, transform.position, transform.rotation);
    }


}
