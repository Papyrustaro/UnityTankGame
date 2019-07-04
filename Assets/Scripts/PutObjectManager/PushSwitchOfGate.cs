using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushSwitchOfGate : MonoBehaviour
{
    private GameObject gateWallPrefab;
    private void Start()
    {
        gateWallPrefab = transform.parent.transform.Find("Wall").gameObject;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            gateWallPrefab.SetActive(!gateWallPrefab.activeSelf);
        }
    }
}
