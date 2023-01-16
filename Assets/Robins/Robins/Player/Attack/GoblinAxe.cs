using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinAxe : Weapons
{
    public Animator goblinArm;
    [SerializeField]
    GameObject hitboxAxe;

    [Header("Sound")]
    public AudioSource goblinSource;
    public AudioClip[] goblinClip;
    public AudioClip swingClip;

    public override void Attack() //Sl�r med yxan  //Robin
    {
        if (!goblinSource.isPlaying)
            goblinSource.PlayOneShot(goblinClip[Random.Range(0, goblinClip.Length)], 1);
        goblinSource.PlayOneShot(swingClip, 1);
        goblinArm.SetBool("Axe", true);
        PlayerAttack.canAttack = false;
        hitboxAxe.SetActive(true);
        PlayerRotation.canRotate = false;
    }

    public override void EndAttack() //Avslutar yx slaget  //Robin
    {
        goblinArm.SetBool("Axe", false);
        hitboxAxe.SetActive(false);
        PlayerRotation.canRotate = true;
        
    }

    public override void RightClick()
    {
        print("RightClick1");
    }
}
