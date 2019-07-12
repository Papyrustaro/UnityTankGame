using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private RaycastHit hit;
    private GameObject headPrefab, turretPrefab;

    private void Start()
    {
        headPrefab = transform.Find("Cannon/Head").gameObject;
        turretPrefab = transform.Find("Cannon/Turret").gameObject;
    }
    public bool RayCastCannon()
    {
        return Physics.Raycast(transform.position, turretPrefab.transform.position - headPrefab.transform.position, out hit, 100f);
    }
    public bool RayCastRight()
    {
        return Physics.Raycast(transform.position, new Vector3(1f, 0f, 0f), out hit, 100f);
    }
    public bool RayCastLeft()
    {
        return Physics.Raycast(transform.position, new Vector3(-1f, 0f, 0f), out hit, 100f);
    }
    public bool RayCastUp()
    {
        return Physics.Raycast(transform.position, new Vector3(0f, 0f, 1f), out hit, 100f);
    }
    public bool RayCastDown()
    {
        return Physics.Raycast(transform.position, new Vector3(0f, 0f, -1f), out hit, 100f);
    }
    public RaycastHit GetRaycastHit()
    {
        return hit;
    }
}
