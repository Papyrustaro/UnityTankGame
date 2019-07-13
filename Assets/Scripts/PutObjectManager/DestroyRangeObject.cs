using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyRangeObject : MonoBehaviour
{
    private EnemyStatus es;
    private ScoreManager sm;
    public GameObject bombExplosionEffectPrefab;
    private GameObject bombEffect;
    // Start is called before the first frame update
    void Start()
    {
        bombEffect = (GameObject)Instantiate(bombExplosionEffectPrefab, this.transform.position, Quaternion.identity);
        Destroy(bombEffect, 2f);
        //Destroy(this.gameObject, 2.1f);
    }

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
            this.gameObject.SetActive(false);

            //GameOverSceneへ
            Invoke("GameOver", 0.5f);
        }
        if (other.CompareTag("DestroyableWall"))
        {
            Destroy(other.gameObject);
        }
    }
    void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
