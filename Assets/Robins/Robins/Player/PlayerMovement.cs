using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    float posX;
    float posY;
    public float speed;

    public Rigidbody2D body;

    public Animator cameraAnim;

    public Animator goblinArm;

    public Animator goblinFeet;

    [Header("Sound")]
    public AudioSource goblinWalking;
    public AudioClip goblinWalkingClip;

    public GameObject Elevator;
    public GameObject exitFade;
    public Animator elevator1;
    public GameObject elevatorDoor;


    // Update is called once per frame
    void Update()
    {
        if (!PlayerAttack.playerDead)
        {
            posX = Input.GetAxis("Horizontal");
            posY = Input.GetAxis("Vertical");

            body.velocity = new Vector2(posX * speed, posY * speed); //S�ter kroppens velocity beroende p� vart du ska g� //Robin

            if (body.velocity.magnitude >= 0.1f) //�ndrar animationer beroende p� om du g�r //Robin
            {
                cameraAnim.SetBool("Moving", true);
                goblinArm.SetBool("Moving", true);
                goblinFeet.SetBool("Moving", true);
                if (!goblinWalking.isPlaying) //spelar ljudet av g�ende med en random pitch //Robin
                {
                    goblinWalking.pitch = Random.Range(0.9f, 1.1f);
                    goblinWalking.PlayOneShot(goblinWalkingClip, 0.2f);
                }
            }
            else //St�nger av animationer //Robin
            {
                cameraAnim.SetBool("Moving", false);
                goblinArm.SetBool("Moving", false);
                goblinFeet.SetBool("Moving", false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.transform.tag == "Enter")
        {
            Elevator.SetActive(true);
            elevator1.SetBool("Close", true);
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Elevator")
        {
            Invoke("NextLevel", 3);
            elevatorDoor.SetActive(true);
            exitFade.SetActive(true);
        }
    }

    void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
