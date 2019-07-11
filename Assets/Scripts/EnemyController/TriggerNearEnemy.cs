using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TriggerNearEnemy : MonoBehaviour
{
    private Action<Collider> enterFunc;
    private Action<Collider> exitFunc;
    private Action<Collider> stayFunc;
    private void OnTriggerEnter(Collider other)
    {
        enterFunc(other);
    }
    private void OnTriggerExit(Collider other)
    {
        exitFunc(other);
    }
    private void OnTriggerStay(Collider other)
    {
        stayFunc(other);
    }
    public void SetFunc(Action<Collider> enterFunc, Action<Collider> exitFunc, Action<Collider> stayFunc)
    {
        this.enterFunc = enterFunc;
        this.exitFunc = exitFunc;
        this.stayFunc = stayFunc;
    }
}
