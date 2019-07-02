using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BomberMan : MonoBehaviour
{
    public GameObject explosionPrefab;
    private float distancePX = 0f; //+x方向の距離
    private float distanceNX = 0f; //-x方向の距離
    private float distancePZ = 0f;
    private float distanceNZ = 0f;
    private GameObject[] explosion = new GameObject[2];
    private void Start()
    {
        RaycastHit hit;
        int layerMask = 1 << 8; //Stageとだけ衝突

        StartCoroutine(DelayMethod(2f, () =>
        {
            SetColorRed();
        }));
        if (Physics.Raycast(this.transform.position, new Vector3(-1f, 0f, 0f), out hit, 100f, layerMask)){
            distanceNX = hit.distance;
        }
        if (Physics.Raycast(this.transform.position, new Vector3(0f, 0f, 1f), out hit, 100f, layerMask))
        {
            distancePZ = hit.distance;
        }
        if (Physics.Raycast(this.transform.position, new Vector3(1f, 0f, 0f), out hit, 100f, layerMask))
        {
            distancePX = hit.distance;
            StartCoroutine(DelayMethod(3f, () =>
            {
                explosionX();
            }));
        }
        if (Physics.Raycast(this.transform.position, new Vector3(0f, 0f, -1f), out hit, 100f, layerMask))
        {
            distanceNZ = hit.distance;
            StartCoroutine(DelayMethod(3f, () =>
            {
                explosionZ();
            }));
        }
    }

    public void explosionX()
    {
        explosion[0] = (GameObject)Instantiate(explosionPrefab, transform.position + new Vector3((distancePX - distanceNX) / 2, 0f, 0f), Quaternion.identity);
        explosion[0].transform.localScale = new Vector3(distancePX + distanceNX, 2f, 2f);
    }
    public void explosionZ()
    {
        explosion[1] = (GameObject)Instantiate(explosionPrefab, transform.position + new Vector3(0f, 0f, (distancePZ - distanceNZ) / 2), Quaternion.identity);
        explosion[1].transform.localScale = new Vector3(2f, 2f, distancePZ + distanceNZ);
        StartCoroutine(DelayMethod(1f, () =>
        {
            DestroyBomb();
        }));
    }
    private void DestroyBomb()
    {
        Destroy(explosion[0]);
        Destroy(explosion[1]);
        Destroy(this.gameObject);
    }

    private void SetColorRed()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }
    private IEnumerator DelayMethod(float waitTime, Action action)
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }
}
