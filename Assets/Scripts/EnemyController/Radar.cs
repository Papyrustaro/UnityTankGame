using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour
{
    private GameObject target;

    void Start()
    {
        target = GameObject.FindWithTag("Player");
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transform.parent.LookAt(target.transform);
        }
    }
}
