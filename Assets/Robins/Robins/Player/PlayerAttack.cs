using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    GameObject hitboxAxe;
    [SerializeField]
    float cooldown;
    public static bool canAttack;

    public int index;
    public Weapons[] weapon;

    [SerializeField]
    GameObject bullet;
    [SerializeField]
    Transform bulletSpawnPoint;

    public static float durability;

    public Animator goblinArm;

    public Rigidbody2D body;

    [Header("Sound")]
    public AudioSource goblinSource;
    public AudioClip[] goblinClip;
    public AudioClip swingClip;
    public AudioClip shootingClip;
    public AudioClip gunClip;

    public AudioSource timeSource;
    public AudioClip timeclip2;

    public GameObject lensDistortion;
    public static bool playerDead;
    // Start is called before the first frame update
    void Start()
    {
        durability = 0;
        canAttack = true;
        hitboxAxe.SetActive(false);
        index = 0;
        playerDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMovement.canmove)
        {
            if (!playerDead)
            {
                if (body.velocity.magnitude >= 0.1f) //Spelar en animation när du går  //Robin
                {
                    goblinArm.SetBool("Moving", true);

                }
                else
                {
                    goblinArm.SetBool("Moving", false);
                }

                if (durability == 0) //Om du har slut på durability  //Robin
                {
                    goblinArm.SetBool("Gun", false);

                    if (index == 1) //om du använder pistolen resettas saker som pistolen gjort  //Robin
                    {
                        Time.timeScale = 1f;
                        if (Input.GetMouseButton(1))
                        {
                            if (timeSource.isPlaying)
                                timeSource.Stop();
                            if (!timeSource.isPlaying)
                                timeSource.PlayOneShot(timeclip2, 0.5f);
                            lensDistortion.SetActive(false);
                        }
                    }
                    index = 0;
                }

                if (Input.GetMouseButtonDown(0) && canAttack) //Slå med vapen  //Robin
                {
                    weapon[index].Attack();
                    Invoke("EndAttack", cooldown);
                }

                weapon[index].RightClick(); //gör det möjligt att använda högerklicks ability  //Robin

            }
        }
    }

    void EndAttack() //avslutar attacken  //Robin
    {
        weapon[index].EndAttack();
        Invoke("Cooldown", cooldown);
    }
    void Cooldown() //cooldown
    {
        canAttack = true;
    }

    public void OnTriggerStay2D(Collider2D other) //Plockar upp vapen
    {
        if(other.transform.tag == "Vapen")
        {
            goblinArm.SetBool("Axe", false);
            goblinArm.SetBool("Gun", false);
            index = other.GetComponent<PickAbleObject>().index;
            durability = other.GetComponent<PickAbleObject>().durability;
            canAttack = true;
            hitboxAxe.SetActive(false);
            PlayerRotation.canRotate = true;
            Destroy(other.gameObject);
        }
    }
}
