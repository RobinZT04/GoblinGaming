using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinPistol : Weapons
{
    public Animator goblinArm;

    [Header("Sound")]
    public AudioSource goblinSource;

    public AudioClip shootingClip;

    [SerializeField]
    GameObject bullet;
    [SerializeField]
    Transform bulletSpawnPoint;

    public override void Attack()
    {
        PlayerAttack.durability -= 1;
        goblinSource.PlayOneShot(shootingClip, 1);
        goblinArm.SetBool("Gun", true);
        PlayerAttack.canAttack = false;
        Instantiate(bullet, bulletSpawnPoint.transform.position, transform.rotation);
        bullet.GetComponent<Bullet>().speed = 10;
        PlayerRotation.canRotate = false;
    }

    public override void EndAttack()
    {
        goblinArm.SetBool("Gun", false);
        PlayerRotation.canRotate = true;
    }
}