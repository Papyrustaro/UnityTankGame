using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyHitPlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        }
    }
}
