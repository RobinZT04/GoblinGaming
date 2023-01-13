using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    GameObject hitboxAxe;
    [SerializeField]
    float cooldown;
    bool canAttack;

    public float index;

    [SerializeField]
    GameObject bullet;
    [SerializeField]
    Transform bulletSpawnPoint;

    public float durability;

    public Animator goblinArm;

    public Rigidbody2D body;

    [Header("Sound")]
    public AudioSource goblinSource;
    public AudioClip goblinClip;
    public AudioClip swingClip;
    public AudioClip shootingClip;
    public AudioClip gunClip;
    // Start is called before the first frame update
    void Start()
    {
        durability = 0;
        canAttack = true;
        hitboxAxe.SetActive(false);
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (body.velocity.magnitude >= 0.1f)
        {
            goblinArm.SetBool("Moving", true);

        }
        else
        {
            goblinArm.SetBool("Moving", false);
        }
        if (durability == 0)
        {
            index = 1;
        }

        if (Input.GetMouseButtonDown(0) && canAttack) //Slå med yxan;
        {
            
            if (index == 1)
            {
                //if(!goblinSource.isPlaying)
                goblinSource.PlayOneShot(goblinClip, 1);
                goblinSource.PlayOneShot(swingClip, 1);
                goblinArm.SetBool("Axe", true);
                Invoke("Attack", cooldown);
                canAttack = false;
                hitboxAxe.SetActive(true);
                PlayerRotation.canRotate = false;
            }
            if (index == 2)
            {
                durability -= 1;
                goblinSource.PlayOneShot(shootingClip, 1);
                Invoke("Shoot", cooldown);
                canAttack = false;
                Instantiate(bullet, bulletSpawnPoint.transform.position, transform.rotation);
                bullet.GetComponent<Bullet>().speed = 10;
                PlayerRotation.canRotate = false;
            }

        }
    }

    void Attack() //Attakerar
    {
        if (index == 1)
        {
            goblinArm.SetBool("Axe", false);
            hitboxAxe.SetActive(false);
            PlayerRotation.canRotate = true;
            Invoke("Cooldown", cooldown);
        }
    }

    void Shoot()
    {
            PlayerRotation.canRotate = true;
            Invoke("Cooldown", cooldown);
    }

    void Cooldown() //cooldown
    {
        canAttack = true;
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if(other.transform.tag == "Vapen")
        {
            goblinArm.SetBool("Axe", false);
            index = other.GetComponent<PickAbleObject>().index;
            durability = other.GetComponent<PickAbleObject>().durability;
            canAttack = true;
            hitboxAxe.SetActive(false);
            PlayerRotation.canRotate = true;
            Destroy(other.gameObject);
        }
    }
}
