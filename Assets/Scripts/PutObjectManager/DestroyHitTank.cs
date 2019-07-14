using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyHitTank : MonoBehaviour
{
    private EnemyStatus es;
    private ScoreManager sm;

    private void OnTriggerEnter(Collider other)
    {
        sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        if (other.gameObject.CompareTag("Enemy"))
        {
            es = GameObject.Find(other.gameObject.transform.root.gameObject.name).GetComponent<EnemyStatus>();
            sm.AddScore(es);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
            //this.gameObject.SetActive(false);

            //GameOverSceneへ
            Invoke("GameOver", 0.5f);
        }
    }
    void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
