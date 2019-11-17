using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowBulletTrajectory : MonoBehaviour
{
    private LineRenderer lr;
    private GameObject head;
    private GameObject turret;

    private void Awake()
    {
        Color color = new Color(1.0f, 0f, 0f, 0.5f);
        head = this.transform.Find("Head").gameObject;
        turret = this.transform.Find("Turret").gameObject;
        lr = GetComponent<LineRenderer>();
        lr.startWidth = 0.2f;
        lr.endWidth = 0.2f;
        lr.positionCount = 2;
    }

    private void Update()
    {
        lr.SetPosition(0, turret.transform.position);
        lr.SetPosition(1, turret.transform.position + ((turret.transform.position - head.transform.position) * 100f));
    }

    /*
    private void MoveTargetPoint()
    {
        var h = Input.GetAxis(GamePadManager.padCannonHorizontal[0]);
        var v = Input.GetAxis(GamePadManager.padCannonVertical[0]);
        this.targetPoint.transform.position += transform.right * h * targetMoveSpeed * Time.deltaTime;
        this.targetPoint.transform.position += transform.forward * v * targetMoveSpeed * Time.deltaTime;
    }*/
}
