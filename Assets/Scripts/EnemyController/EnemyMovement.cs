using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed;
    private CharacterController controller;
    public GameObject target;
    private GameObject cannonPrefab;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        cannonPrefab = transform.Find("Cannon").gameObject;
    }

    private void Update()
    {
    }

    public void Move(float x, float z)
    {
        float rad = Mathf.Atan2(z, x);
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
        controller.SimpleMove(new Vector3(0f, 0f, moveSpeed));
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

}
