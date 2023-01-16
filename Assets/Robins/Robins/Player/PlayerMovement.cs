using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Update is called once per frame
    void Update()
    {
        posX = Input.GetAxis("Horizontal");
        posY = Input.GetAxis("Vertical");

        body.velocity = new Vector2(posX * speed, posY * speed); //Säter kroppens velocity beroende på vart du ska gå //Robin

        if (body.velocity.magnitude >= 0.1f) //ändrar animationer beroende på om du går //Robin
        {
            cameraAnim.SetBool("Moving", true);
            goblinArm.SetBool("Moving", true);
            goblinFeet.SetBool("Moving", true);
            if (!goblinWalking.isPlaying) //spelar ljudet av gående med en random pitch //Robin
            {
                goblinWalking.pitch = Random.Range(0.9f, 1.1f);
                goblinWalking.PlayOneShot(goblinWalkingClip, 0.2f);
            }
        }
        else //Stänger av animationer //Robin
        {
            cameraAnim.SetBool("Moving", false);
            goblinArm.SetBool("Moving", false);
            goblinFeet.SetBool("Moving", false);
        }
    }
}
