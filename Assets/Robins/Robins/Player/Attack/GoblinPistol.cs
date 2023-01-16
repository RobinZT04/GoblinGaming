using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class GoblinPistol : Weapons
{
    public Animator goblinArm;

    [Header("Sound")]
    public AudioSource goblinSource;

    public AudioClip shootingClip;

    public AudioSource timeSource;
    public AudioClip timeclip1;
    public AudioClip timeclip2;

    [SerializeField]
    GameObject bullet;
    [SerializeField]
    Transform bulletSpawnPoint;

    public SpriteRenderer sprite;
    public Sprite gun;

    public GameObject lensDistortion;


    public override void Attack() //skjuter med pistolen  //Robin
    {
        goblinArm.SetBool("GunIdle", false);
        goblinSource.PlayOneShot(shootingClip, 1);
        goblinArm.SetBool("Gun", true);
        PlayerAttack.canAttack = false;
        Instantiate(bullet, bulletSpawnPoint.transform.position, transform.rotation);
        bullet.GetComponent<Bullet>().speed = 10;

        PlayerRotation.canRotate = false;
    }

    public override void EndAttack() //avslutar skjuta med pistolen  //Robin
    {
        sprite.sprite = gun;
        goblinArm.SetBool("GunIdle", true);
        PlayerRotation.canRotate = true;
        PlayerAttack.durability -= 1;
    }

    public override void RightClick() //använder ability (sakta ned tiden)  //Robin
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (timeSource.isPlaying)
                timeSource.Stop();
            if (!timeSource.isPlaying)
                timeSource.PlayOneShot(timeclip1, 0.2f);
            lensDistortion.SetActive(true);
            Time.timeScale = 0.65f;
        }
        if (Input.GetMouseButtonUp(1))
        {
            if (timeSource.isPlaying)
                timeSource.Stop();
                if (!timeSource.isPlaying)
                timeSource.PlayOneShot(timeclip2, 0.2f);
            lensDistortion.SetActive(false);
            Time.timeScale = 1f;
        }


    }
}