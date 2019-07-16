using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByAttack : MonoBehaviour
{
    public int hp;
    private PutObject po;

    private bool alive = true;
    private void Update()
    {
        if(!alive || hp <= 0)
        {
            po.DestroyObject(this.gameObject);
            Destroy(this.gameObject);
        }
    }

    public void SetPutter(PutObject po)
    {
        this.po = po;
    }
    public void hitBullet()
    {
        this.hp--;
    }
}
