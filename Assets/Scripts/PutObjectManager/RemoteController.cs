using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteController : MonoBehaviour
{
    private Rigidbody rb;
    private GameObject player;
    private GameObject shotBullet;
    public float forcePower = 30f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player");
        shotBullet = player.transform.Find("Cannon/ShotBullet").gameObject;
    }

    private void FixedUpdate()
    {
        Vector3 v = new Vector3(shotBullet.transform.position.x - player.transform.position.x,
            0f, shotBullet.transform.position.z - player.transform.position.z);
        rb.AddForce(v * forcePower);
    }
}