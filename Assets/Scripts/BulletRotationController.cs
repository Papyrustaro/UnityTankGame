using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRotationController : MonoBehaviour
{
    private Vector3 bulletPos;
    // Start is called before the first frame update
    void Start()
    {
        bulletPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 diff = transform.position - bulletPos;
        if(diff.magnitude > 0.01f)
        {
            transform.rotation = Quaternion.LookRotation(diff);
        }
        bulletPos = transform.position;
    }
}
