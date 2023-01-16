using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SleepyMovement : MonoBehaviour
{

    public Transform player;
    public float movementSpeed;
    GameObject trash;
    bool collecting;

    [SerializeField]
    AudioSource sleepySource;
    [SerializeField]
    AudioClip sleepyClip;
    // Start is called before the first frame update
    void Start()
    {
        collecting = false;
    }

    // Update is called once per frame
    void Update()
    {
        TrashCode();
        Rotate();
    }

    void Rotate()
    {
        if(transform.position.x <= player.transform.position.x) //ändrar spritens vinkel beroende på din poistion //Robin
        {
            transform.eulerAngles = new Vector2(0, 0);
        }else
            transform.eulerAngles = new Vector2(0, 180);
    }
    void TrashCode()
    {

        if (Vector2.Distance(transform.position, player.transform.position) >= 0.15f && !collecting) //åker efter spelaren  //Robin
        {
            //GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            //transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 0.1f);
            transform.position += (player.transform.position - transform.position).normalized * movementSpeed * Time.deltaTime;
        }

        if (GameObject.FindGameObjectWithTag("Trash") != null) //om det inte finns ´skräp håller den sig vid spelaren  //Robin
        {
            GameObject trash = GameObject.FindGameObjectWithTag("Trash");
            collecting = true;

            if (collecting) //åker till skräpet och äter det  //Robin
                transform.position += (trash.transform.position - transform.position).normalized * movementSpeed * Time.deltaTime;

            if (Vector2.Distance(transform.position, trash.transform.position) <= 0.15f) //om den är på skräpet plockas skräpet och du får pöäng //Robin
            {
                Destroy(trash);
                if (!sleepySource.isPlaying)
                {
                    sleepySource.PlayOneShot(sleepyClip, 1);
                }
                ScoreManager.score += 100;
                collecting = false;
            }

        }

    }
}
