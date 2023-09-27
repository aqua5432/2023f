using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject explosion;
    public GameObject damage;
    [SerializeField] int EnemyLife = 50;
    [SerializeField] int bossjudge = 1;
    private int Life;
    private bool isDestroyed;
    public GameObject[] EnemyList;
    private GameObject[] enemyBox;
    private int damagescale;
    private int damagelog;
    [SerializeField] int damagescaleamount = 10;

    void Start()
    {
        isDestroyed = false;
        int difficulty = (int)PlayerPrefs.GetFloat("Difficulty", 1);
        Debug.Log(difficulty);
        Life = difficulty * EnemyLife;
        damagescale = 1;
        damagelog = 0;
    }

    void Update()
    {
        enemyBox = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemyBox.Length == 1)
        {
            damagescale = damagescaleamount;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Bullet" && !isDestroyed)
        {
            TakeDamage(5); // ダメージを与える
        }
    }

    public void TakeDamage(int damageAmount)
    {
        if (!isDestroyed)
        {
            damagelog = damageAmount * damagescale;
            Life -= damagelog;
            Instantiate(damage.gameObject, this.transform.position, Quaternion.identity);
        }
        if (Life <= 0)
        {
            DestroyEnemy();
            UpdateScore();
        }
    }

    private void DestroyEnemy()
    {
        Instantiate(explosion.gameObject, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
        SEManager.instance.PlaySE(2);
        isDestroyed = true;
    }

    private void UpdateScore()
    {
        var sceneManager = Object.FindObjectOfType<MySceneManager>();

        if (bossjudge == 1)
        {
            sceneManager.AddScore(1000);
            int number = PlayerPrefs.GetInt("Enemy");
            ++number;
            PlayerPrefs.SetInt("Enemy", number);
            PlayerPrefs.Save();
        }
        else
        {
            sceneManager.AddScore(5000);
            int bossnumber = PlayerPrefs.GetInt("Boss");
            ++bossnumber;
            PlayerPrefs.SetInt("Boss", bossnumber);
            PlayerPrefs.Save();
        }
    }
}
