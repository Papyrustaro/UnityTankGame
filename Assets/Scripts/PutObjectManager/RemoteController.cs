using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
        try{
            Vector3 v = new Vector3(shotBullet.transform.position.x - controllObject.transform.position.x,
            0f, shotBullet.transform.position.z - controllObject.transform.position.z);
            rb.AddForce(v * forcePower);
        }catch(Exception)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("EnemyBullet") || collision.gameObject.CompareTag("SpecialBullet"))
        {
            try
            {
                collision.gameObject.GetComponent<BulletController>().DestroyBullet(collision.gameObject);
                this.controllObject.GetComponent<PutObject>().PutRemoteBombPrefab();
            }
            catch (Exception)
            {
                Destroy(this.gameObject);
            }
        }
        if (collision.gameObject.CompareTag("AttackFlag"))
        {
            try
            {
                this.controllObject.GetComponent<PutObject>().PutRemoteBombPrefab();
            }
            catch (Exception)
            {
                Destroy(this.gameObject);
            }
        }
    }
    public void SetController(GameObject controllObject, GameObject shotBullet)
    {
        this.controllObject = controllObject;
        this.shotBullet = shotBullet;
    }
}