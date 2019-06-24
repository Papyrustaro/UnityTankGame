using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UseSkill : MonoBehaviour
{
    public float speedUpMagni = 2f; //何倍のスピードになるか
    public float speedUpTime = 3f; //スキル適用時間
    public float speedUpInterval = 10f; //スキルを使用してから次使えるまで
    private float countTime;
    private bool isSpeedUp = false;

    private TankMovement tm;
    // Start is called before the first frame update
    void Start()
    {
        tm = GetComponent<TankMovement>();
        countTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        countTime += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.F) && countTime >= speedUpInterval)
        {
            countTime = 0f;
            useSkillSpeedUp();
        }
    }

    private IEnumerator DelayMethod(float waitTime, Action action)
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }

    public void useSkillSpeedUp()
    {
        isSpeedUp = true;
        tm.setMoveSpeed(speedUpMagni);
        StartCoroutine(DelayMethod(speedUpTime, () =>
        {
            tm.setMoveSpeed(1 / speedUpMagni);
            isSpeedUp = false;
        }));
    }
}
