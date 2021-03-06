﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    public float moveSpeed = 3.5f;
    private float x = 0f;
    private float z = 0f;
    Rigidbody rb;
    private Vector3 movement;
    private int gamePadNum;
    private bool ableMove = true;

    private PlayerTankParameter ptp;

    private void Awake()
    {
        ptp = transform.gameObject.GetComponent<PlayerTankParameter>();
        moveSpeed *= ptp.GetMoveSpeedMagni();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gamePadNum = GetComponent<GamePadManager>().GetGamePadNum();
    }

    void FixedUpdate()
    {
        if (ableMove)
        {
            x = Input.GetAxis(GamePadManager.padHorizontal[gamePadNum]) * moveSpeed;
            z = Input.GetAxis(GamePadManager.padVertical[gamePadNum]) * moveSpeed;
            movement = transform.forward * z * moveSpeed * Time.deltaTime
                + transform.right * x * moveSpeed * Time.deltaTime;
            rb.MovePosition(rb.position + movement);
        }
    }

    public float getMoveSpeed()
    {
        return moveSpeed;
    }
    public void setMoveSpeed(float magnification)
    {
        this.moveSpeed *= magnification;
    }

    public void SetAbleMove(bool ableMove)
    {
        this.ableMove = ableMove;
    }
}
