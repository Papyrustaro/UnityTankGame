using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteController : MonoBehaviour
{
    private Rigidbody rb;
    private GameObject controllObject;
    private GameObject shotBullet;
    public float forcePower = 30f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 v = new Vector3(shotBullet.transform.position.x - controllObject.transform.position.x,
            0f, shotBullet.transform.position.z - controllObject.transform.position.z);
        rb.AddForce(v * forcePower);
    }
    public void SetController(GameObject controllObject, GameObject shotBullet)
    {
        this.controllObject = controllObject;
        this.shotBullet = shotBullet;
    }
}