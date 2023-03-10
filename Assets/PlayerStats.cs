using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public static int hp;
    Image healthBar;
    public Sprite[] healthStates;

    public Animator goblinHead;

    public AudioSource goblinSource;
    public AudioClip goblinClip;
    public GameObject postProcess;
    public GameObject GameOver;

    public GameObject body1;
    public GameObject body2;

    bool addDeath;

    // Start is called before the first frame update
    void Start()
    {
        addDeath = false;
        healthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<Image>();
        hp = 2;  
    }

    // Update is called once per frame
    void Update()
    {
        if(hp >= 0 && hp <=2) //hp sprite ?ndras beroende p? hp
        healthBar.sprite = healthStates[hp];
        //print(hp);
        if(hp <= 0)
        {
            goblinHead.SetBool("Dead", true);
            body1.SetActive(false);
            body2.SetActive(false);
            PlayerAttack.playerDead = true;
            GameOver.SetActive(true);
            if (!addDeath)
            {
                ScoreManager.deathCount += 1;
                addDeath = true;
            }
            Invoke("Restart", 1);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.transform.tag == "EW") //"Enemy weapon" du tar skada
        {
            hp -= 1;
            goblinHead.SetBool("Damage", true);
            postProcess.SetActive(true);
            goblinSource.PlayOneShot(goblinClip, 0.5f);
            Invoke("ResetAnim", 0.3f);
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.transform.tag == "Healing")
        {
            hp = 2;
            //healthBar.sprite = healthStates[hp];
            //healthBar.sprite = healthStates[hp];
            Destroy(other.gameObject);
        }
    }

    void ResetAnim()
    {
        goblinHead.SetBool("Damage", false);
        Invoke("ResetBlood", 0.4f);
    }

    void ResetBlood()
    {
        postProcess.SetActive(false);
    }
}
