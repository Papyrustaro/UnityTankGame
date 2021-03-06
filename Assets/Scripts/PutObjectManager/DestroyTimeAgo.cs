﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTimeAgo : MonoBehaviour
{
    public float destroyTime;
    private PutObject po;
    // Update is called once per frame
    void Update()
    {
        destroyTime -= Time.deltaTime;
        if(destroyTime <= 0f)
        {
            try
            {
                po.DestroyObject(this.gameObject);
            }
            catch (MissingReferenceException)
            {
            }
            Destroy(this.gameObject);
        }
    }

    public void SetPutter(PutObject po)
    {
        this.po = po;
    }
}
