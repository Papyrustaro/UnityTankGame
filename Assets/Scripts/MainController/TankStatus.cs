using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankStatus : MonoBehaviour
{
    private bool isAlive = true;
    
    public void SetIsAlive(bool flag)
    {
        this.isAlive = flag;
    }
    public bool GetIsAlive()
    {
        return this.isAlive;
    }
}
