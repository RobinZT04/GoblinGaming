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

    public Transform[] pathPos; //Elanor
    public int nuvarandeposition; //Elanor
    public bool chasing; //Elanor 

    public bool DEAD;

    bool CanShoot;

    public GameObject bulletEnemy;
    public Transform humanRot;

    public Transform bulletSpawn;

    public AudioSource enemySource;
    public AudioClip enemyStep;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        chasing = false;//Elanor
        nuvarandeposition = 0; //Elanor
        CanShoot = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!DEAD)
        {
            if (Vector3.Distance(transform.position, player.transform.position) <= 5) //Elanor
            {
                chasing = true;
                humanBody.chasing = true;

            }
            if (chasing) //Elanor
            {
                if (Vector3.Distance(transform.position, player.transform.position) <= 4) //Elanor
                {
                    humanBody.chasing = false;
                    if (!CanShoot)
                    {
                        Instantiate(bulletEnemy, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
                        Invoke("Cooldown", 1);
                        CanShoot = true;
                    }
                    agent.isStopped = true;
                }
                else
                {
                    if (!enemySource.isPlaying)
                    {
                        enemySource.PlayOneShot(enemyStep, 1);
                    }
                    agent.isStopped = false;
                }


                agent.SetDestination(new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z)); //Robin
                humanBody.Invoke("Head", 0); //Robin 
                chasing = true; //Elanor
            }

            transform.eulerAngles = new Vector3(0, 0, 0); //Robin

            if (!chasing) //Elanor - Gubben rör sig mot nästa position när den har gått till sista positionen resetas det.
            {
                transform.position = Vector2.MoveTowards(transform.position, pathPos[nuvarandeposition].transform.position, 1 * Time.deltaTime); //Elanor
                if (Vector3.Distance(transform.position, pathPos[nuvarandeposition].transform.position) <= 0.2f) //Elanor
                {
                    nuvarandeposition += 1; //Elanor
                }

                if (nuvarandeposition == pathPos.Length) //Elanor
                {
                    nuvarandeposition = 0; //Elanor
                }

            }

        }
    }

    void Cooldown()
    {
        CanShoot = false;
    }

}
