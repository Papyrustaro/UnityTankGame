using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTankFloor : MonoBehaviour
{
    public float forceX;
    public float forceZ;
    private void FixedUpdate()
    {
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            rb.MovePosition(rb.position + new Vector3(forceX * Time.deltaTime, 0f, forceZ * Time.deltaTime));
        }
    }
}
