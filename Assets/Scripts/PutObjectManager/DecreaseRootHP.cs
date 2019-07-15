using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecreaseRootHP : MonoBehaviour
{
    private DestroyByAttack root;
    // Start is called before the first frame update
    void Start()
    {
        root = transform.root.GetComponent<DestroyByAttack>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("EnemyBullet") || collision.gameObject.CompareTag("SpecialBullet"))
        {
            root.hitBullet();
        }
    }
}
