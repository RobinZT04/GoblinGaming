using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static int hp;
    Image healthBar;
    public Sprite[] healthStates;

    public Animator goblinHead;

    public AudioSource goblinSource;
    public AudioClip goblinClip;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<Image>();
        hp = 2;  
    }

    // Update is called once per frame
    void Update()
    {
        if(hp >= 0 && hp <2) //hp sprite ändras beroende på hp
        healthBar.sprite = healthStates[hp];
        //print(hp);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.transform.tag == "EW") //"Enemy weapon" du tar skada
        {
            hp -= 1;
            goblinHead.SetBool("Damage", true);
            goblinSource.PlayOneShot(goblinClip, 0.5f);
            Invoke("ResetAnim", 0.2f);
            Destroy(other.gameObject);
        }
    }

    void ResetAnim()
    {
        goblinHead.SetBool("Damage", false);
    }
}
