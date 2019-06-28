using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTimeAgo : MonoBehaviour
{
    public float destroyTime;

    // Update is called once per frame
    void Update()
    {
        destroyTime -= Time.deltaTime;
        if(destroyTime <= 0f)
        {
            Destroy(this.gameObject);
        }
    }
}
