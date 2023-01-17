using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanBody : MonoBehaviour
{
    [SerializeField]
    Transform body;
    [SerializeField]
    Rigidbody2D bodyRB;

    public bool DEAD;


    GameObject player;

    public Animator enemyBody;
    public Animator enemyFeet;

    public bool chasing;

    public bool animate;

    public Vector3 bDeath;

    private void Awake()
    {
        chasing = false;
    }
    // Start is called before the first frame update
    void Update()
    {
        if (DEAD)
        {
            transform.position = bDeath;
        }
        if (!DEAD)
        {
            bDeath = transform.position;
            if (animate) //ändrar animationer för fiende  //Robin
            {
                enemyBody.SetBool("Moving", true);
                enemyFeet.SetBool("Moving", true);
            }
            else
            {
                enemyBody.SetBool("Moving", false);
                enemyFeet.SetBool("Moving", false);
            }

            transform.position = body.transform.position;
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    // Update is called once per frame
    public void Head()
    {
        if (!DEAD)
        {
            //vänder sig mot spelaren //Robin
            Vector2 direction = new Vector2 //Vector2 direction är new vector2
         (
         player.transform.position.x - transform.position.x, //tar musens positon.x - transform.position.x
         player.transform.position.y - transform.position.y //tar musens positon.y - transform.position.y
         );

            transform.up = direction; //transform.up ör nu likamed direction
        }
    }
}
