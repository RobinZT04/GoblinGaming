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
            goblinArm.SetBool("Gun", false);
            index = 0;
        }

        if (Input.GetMouseButtonDown(0) && canAttack) //Slå med yxan;
        {
            weapon[index].Attack();
            Invoke("EndAttack", cooldown);
            if (index == 2)
            {
 
            }

        }
    }

    void EndAttack() //Attakerar
    {
        weapon[index].EndAttack();
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
