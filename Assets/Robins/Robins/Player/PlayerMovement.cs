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

    // Update is called once per frame
    void Update()
    {
        posX = Input.GetAxis("Horizontal");
        posY = Input.GetAxis("Vertical");

        body.velocity = new Vector2(posX * speed, posY * speed);

        if(body.velocity.magnitude >= 0.1f)
        {
            cameraAnim.SetBool("Moving", true);
            goblinArm.SetBool("Moving", true);
            goblinFeet.SetBool("Moving", true);
        }
        else
        {
            cameraAnim.SetBool("Moving", false);
            goblinArm.SetBool("Moving", false);
            goblinFeet.SetBool("Moving", false);
        }
    }
}
