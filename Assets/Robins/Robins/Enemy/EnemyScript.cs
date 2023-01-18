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

    public GameObject[] pathPos; //Elanor
    public int nuvarandeposition; //Elanor
    public bool chasing; //Elanor 



    bool CanShoot;

    public GameObject bulletEnemy;
    public Transform humanRot;

    public Transform bulletSpawn;

    public AudioSource enemySource;
    public AudioClip enemyStep;

    public bool goAround;

    RaycastHit2D hit;

    public AudioClip enemyShot; //Elanor



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
        if (!humanBody.DEAD && !PlayerAttack.playerDead)
        {
            if (Vector3.Distance(transform.position, player.transform.position) <= 4) //Elanor
            {
                chasing = true;
                humanBody.chasing = true;

            }
            if (chasing) //Elanor
            {
                    if (Vector3.Distance(transform.position, player.transform.position) <= 3) //Elanor
                    {

                        hit = Physics2D.Raycast(humanRot.transform.position, humanRot.transform.up, 4); //Skickar ut en raycast //Robin
                    Debug.DrawRay(humanRot.transform.position, humanRot.transform.up, Color.green, 4);


                    if (hit.collider != null) //om du träffar ett objekt //Robin
                    {
                        //print(hit.collider.gameObject.tag);
                        if(hit.collider.gameObject.tag == "Player") //om objektet är spelaren  //Robin
                        {
                        if (!CanShoot) //om du kan skjuta skjuter gubben //Robin
                            {
                                humanBody.animate = false;
                                Instantiate(bulletEnemy, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
                                Invoke("Cooldown", 1);
                                CanShoot = true;
                                agent.isStopped = true;

                                enemySource.PlayOneShot(enemyShot, 0.2f); //Elanor
                            }
                        }
                        else //annars fortsätter den att försöka hitta spelaren //Robin
                        {
                            agent.isStopped = false;
                        }
                    }
                        
                }
                else
                {
                    humanBody.animate = true;
                    if (!enemySource.isPlaying) //om gubben går spelas ljudet //Robin
                    {
                        enemySource.PlayOneShot(enemyStep, 0.2f);
                    }
                    agent.isStopped = false; //gubben kan gå //Robin
                }


                agent.SetDestination(new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z)); //Robin
                humanBody.Invoke("Head", 0); //Robin 
                chasing = true; //Elanor
                transform.eulerAngles = new Vector3(0, 0, 0); //Robin
            }



            if (!chasing) //Elanor - Gubben rör sig mot nästa position när den har gått till sista positionen resetas det.
            {
                agent.isStopped = false;
                //agent.SetDestination(new Vector3(pathPos[nuvarandeposition].transform.position.x, pathPos[nuvarandeposition].transform.position.y, transform.position.z)); //Robin
                transform.position = Vector2.MoveTowards(transform.position, pathPos[nuvarandeposition].transform.position, 1 * Time.deltaTime); //Elanor

                Vector2 direction = new Vector2 //Vector2 direction är new vector2
         (
         pathPos[nuvarandeposition].transform.position.x - transform.position.x, //tar musens positon.x - transform.position.x
         pathPos[nuvarandeposition].transform.position.y - transform.position.y //tar musens positon.y - transform.position.y
         );

                humanBody.animate = true;
                humanRot.transform.up = direction; //transform.up ör nu likamed direction
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
