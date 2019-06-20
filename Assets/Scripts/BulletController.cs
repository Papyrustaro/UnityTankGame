using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletController : MonoBehaviour
{
    public int bounceAble = 1;
    private bool hit = false;

    private void OnCollisionEnter(Collision col)
    {
        if(hit == false)
        {
            hit = true;
            if (col.gameObject.CompareTag("Stage"))
            {
                bounceAble--;
                if (bounceAble < 0)
                {
                    Destroy(this.gameObject);
                }
            }
            if (col.gameObject.CompareTag("Enemy"))
            {
                Destroy(col.gameObject);
                Destroy(this.gameObject);
            }
            if (col.gameObject.CompareTag("Player"))
            {
                col.gameObject.SetActive(false);
                this.gameObject.SetActive(false);

                //GameOverSceneへ
                Invoke("GameOver", 0.5f);
            }
        }
    }

    private void OnCollisionExit(Collision col)
    {
        hit = false;
    }

    void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
