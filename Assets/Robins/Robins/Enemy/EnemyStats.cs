using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public GameObject trash;
    public GameObject Enemy;
    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.transform.tag == "Damage")
        {
            print("YEES");
            Instantiate(trash, transform.position, Quaternion.identity);
            Destroy(Enemy);
        }
    }
}
