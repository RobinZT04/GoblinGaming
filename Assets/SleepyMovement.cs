using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SleepyMovement : MonoBehaviour
{

    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.transform.position) >= 3)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 0.1f);
        }

            
    }
}
