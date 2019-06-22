using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    private float x = 0f;
    private float z = 0f;
    Rigidbody rb;
    private Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        x = Input.GetAxis("Horizontal") * moveSpeed;
        z = Input.GetAxis("Vertical") * moveSpeed;
        movement = transform.forward * z * moveSpeed * Time.deltaTime 
            + transform.right * x * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
    }
}
