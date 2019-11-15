using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowBulletTrajectory : MonoBehaviour
{
    private LineRenderer lr;
    private float count;
    private GameObject head;
    private GameObject turret;

    private void Awake()
    {
        Color color = new Color(1.0f, 0f, 0f, 0.5f);
        head = this.transform.Find("Head").gameObject;
        turret = this.transform.Find("Turret").gameObject;
        lr = GetComponent<LineRenderer>();
        lr.startWidth = 0.1f;
        lr.endWidth = 0.1f;
        lr.positionCount = 2;
        lr.startColor = color;
        lr.endColor = color;
    }

    private void Update()
    {
        lr.SetPosition(0, turret.transform.position);
        lr.SetPosition(1, turret.transform.position + ((turret.transform.position - head.transform.position) * 100f));
    }
}
