using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    
    GameObject player;
    [SerializeField]
    NavMeshAgent agent;
    [SerializeField]
    HumanBody humanBody;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, player.transform.position) <= 5)
        {
            agent.SetDestination(new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z));
            humanBody.Invoke("Head", 0);
        }

        transform.eulerAngles = new Vector3(0, 0, 0);
    }
}
