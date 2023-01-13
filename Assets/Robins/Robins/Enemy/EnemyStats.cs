using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public GameObject trash;
    public GameObject Enemy;
    [Header("Sound")]
    public AudioSource enemySource;
    public AudioClip enemyClip;
    public EnemyScript enemy;
    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.transform.tag == "Damage")
        {
            print("YEES");
            Instantiate(trash, transform.position, Quaternion.identity);
            enemySource.PlayOneShot(enemyClip, 1);
            Death();
        }
    }

    void Death()
    {
        enemy.DEAD = true;
    }
}
