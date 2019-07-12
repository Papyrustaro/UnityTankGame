using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemyAI : MonoBehaviour
{
    private EnemyShotManager esm;
    private RaycastHit hit;
    private GameObject head;
    private GameObject turret;
    void Start()
    {
        esm = GetComponent<EnemyShotManager>();
        head = this.transform.Find("Cannon/Head").gameObject;
        turret = this.transform.Find("Cannon/Turret").gameObject;

    }
    private void Update()
    {
        if(Physics.Raycast(this.transform.position, turret.transform.position - head.transform.position, out hit, 50f))
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                esm.Shot();
            }
        }
    }

}
