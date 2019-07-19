using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotAI : MonoBehaviour
{
    public int bulletBounceNum;
    private EnemyController ec;
    private EnemyShotManager esm;
    private float countTime = 0f;
    private GameObject target;
    private GameObject cannon;

    private void Awake()
    {
        ec = GetComponent<EnemyController>();
        esm = GetComponent<EnemyShotManager>();
        cannon = transform.Find("Cannon").gameObject;
    }
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        countTime += Time.deltaTime;
        cannon.transform.LookAt(target.transform);
        if(countTime > 1f)
        {
            if (ec.GetRaycastCannon().transform.CompareTag("Player"))
            {
                Debug.Log("てきだ");
                esm.Shot();
            }
            countTime = 0f;
        }

    }
}
