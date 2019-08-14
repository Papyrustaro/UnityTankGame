using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerFirstPosition : MonoBehaviour
{
    public GameObject[] tankPrefab = new GameObject[21];
    private void Awake()
    {
        Instantiate(tankPrefab[SingleMissionStaticData.selectTankNumber], this.transform.position, this.transform.rotation);
    }
}
