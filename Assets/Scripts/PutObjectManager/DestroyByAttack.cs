using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByAttack : MonoBehaviour
{
    public int hp;

    private bool alive = true;
    private void Update()
    {
        if(!alive || hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    public void hitBullet()
    {
        this.hp--;
    }
}
