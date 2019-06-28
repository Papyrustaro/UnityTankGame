using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutObject : MonoBehaviour
{
    public GameObject batteryPrefab;
    public GameObject protectDomePrefab;

    public void PutBatteryPrefab()
    {
        GameObject BatteryPrefab = (GameObject)Instantiate(batteryPrefab, transform.position, transform.rotation);
    }
    public void PutProtectDomePrefab()
    {
        GameObject ProtectDomePrefab = (GameObject)Instantiate(protectDomePrefab, transform.position, Quaternion.identity);
    }


}
