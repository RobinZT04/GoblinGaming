using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public GameObject trash;
    public GameObject Enemy;
    [Header("Sound")]
    public AudioSource enemySource;
    public AudioClip[] enemyClip;
    public HumanBody enemy;
    //RaycastHit2D hit;

    public void OnCollisionEnter2D(Collision2D other) //Fiende tar skada och spelar ett random ljud när dem dör //Robin
    {
        if(other.transform.tag == "Damage")
        {
            if (!enemy.DEAD)
            {
                ScoreManager.kills += 1;
                Instantiate(trash, transform.position, Quaternion.identity);
                enemySource.PlayOneShot(enemyClip[Random.Range(0, enemyClip.Length)], 0.5f);
                Death();
            }
        }
    }

    void Death()
    {
        enemy.DEAD = true;
    }
}
