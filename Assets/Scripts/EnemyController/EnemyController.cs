using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyController : MonoBehaviour
{
    private RaycastHit hit;
    private GameObject headPrefab, turretPrefab;

    public float moveSpeed;
    private CharacterController controller;
    private GameObject cannonPrefab;
    private GameObject player;

    private void Awake()
    {
        headPrefab = transform.Find("Cannon/Head").gameObject;
        turretPrefab = transform.Find("Cannon/Turret").gameObject;
        controller = GetComponent<CharacterController>();
        cannonPrefab = transform.Find("Cannon").gameObject;
    }

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    public void Move(float x, float z)
    {
        float rad = Mathf.Atan2(z, x);
        controller.SimpleMove(new Vector3(moveSpeed * Mathf.Cos(rad), 0f, moveSpeed * Mathf.Sin(rad)));
    }
    public void Move(Vector3 v)
    {
        float rad = Mathf.Atan2(v.z, v.x);
        controller.SimpleMove(new Vector3(moveSpeed * Mathf.Cos(rad), 0f, moveSpeed * Mathf.Sin(rad)));
    }
    public void MoveRight()
    {
        controller.SimpleMove(new Vector3(moveSpeed, 0f, 0f));
    }
    public void MoveLeft()
    {
        controller.SimpleMove(new Vector3(-moveSpeed, 0f, 0f));
    }
    public void MoveUp()
    {
        controller.SimpleMove(new Vector3(0f, 0f, moveSpeed));
    }
    public void MoveDown()
    {
        controller.SimpleMove(new Vector3(0f, 0f, -moveSpeed));
    }

    //上を0として右回転
    public void TurnCannon(float angle)
    {
        cannonPrefab.transform.rotation = Quaternion.AngleAxis(angle, new Vector3(0, 1, 0));
    }
    public void TurnCannonAdd(float angle)
    {
        cannonPrefab.transform.Rotate(0, angle, 0);
    }

    public RaycastHit GetRaycastToPlayer()
    {
        Physics.Raycast(transform.position + new Vector3(0f, 0.5f, 0f), player.transform.position - transform.position, out hit, 100f);
        return hit;
    }

    public RaycastHit GetRaycastCannon(int bounceNum)
    {
        if (bounceNum >= 3) bounceNum = 3;

        Vector3 v = turretPrefab.transform.position - headPrefab.transform.position;
        Vector3 v2 = Quaternion.Euler(0, -90f, 0) * v;
        Vector3 from = transform.position + v2 * 0.4f + new Vector3(0f, 0.5f, 0f);

        for(int i = 0; i < 2; i++) //弾の左端と右端で2セット
        {
            Physics.Raycast(from, v, out hit, 100f);
            if (!hit.transform.CompareTag("Stage") && !hit.transform.CompareTag("Wall"))
            {
                return hit;
            }

            v = hit.point - transform.position;

            for (int j = 0; j < bounceNum; j++)
            {
                //この場合はxかz軸に平行な壁でしか正しく動かない
                if (hit.normal.x == 0)
                {
                    v = new Vector3(v.x, 0f, v.z * -1);
                }
                else
                {
                    v = new Vector3(v.x * -1, 0f, v.z);
                }
                Physics.Raycast(hit.point, v, out hit, 100f);
                if (!hit.transform.CompareTag("Stage") && !hit.transform.CompareTag("Wall"))
                {
                    return hit;
                }
            }
            from -= v2 * 2f;
        }

        return hit;
    }
    public RaycastHit GetRaycastCannon()
    {
        Physics.Raycast(transform.position, turretPrefab.transform.position - headPrefab.transform.position, out hit, 100f);
        return hit;
    }
    public bool RaycastCannon()
    {
        return Physics.Raycast(transform.position, turretPrefab.transform.position - headPrefab.transform.position, out hit, 100f);
    }
    public bool RaycastRight()
    {
        return Physics.Raycast(transform.position, new Vector3(1f, 0f, 0f), out hit, 100f);
    }
    public bool RaycastLeft()
    {
        return Physics.Raycast(transform.position, new Vector3(-1f, 0f, 0f), out hit, 100f);
    }
    public bool RaycastUp()
    {
        return Physics.Raycast(transform.position, new Vector3(0f, 0f, 1f), out hit, 100f);
    }
    public bool RaycastDown()
    {
        return Physics.Raycast(transform.position, new Vector3(0f, 0f, -1f), out hit, 100f);
    }
    public RaycastHit GetRaycastHit()
    {
        return hit;
    }

    public void SetTriggerFunc(Action<Collider> bodyEnterFunc, Action<Collider> bodyExitFunc, Action<Collider> bodyStayFunc,
        Action<Collider> nearEnterFunc, Action<Collider> nearExitFunc, Action<Collider> nearStayFunc)
    {
        TriggerBodyEnemy tbe = transform.Find("Body").gameObject.GetComponent<TriggerBodyEnemy>();
        TriggerNearEnemy tne = transform.Find("Cannon").gameObject.GetComponent<TriggerNearEnemy>();
        tbe.SetFunc(bodyEnterFunc, bodyExitFunc, bodyStayFunc);
        tne.SetFunc(nearEnterFunc, nearExitFunc, nearStayFunc);
    }
}
