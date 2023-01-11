using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float posX;
    float posY;
    public float speed;

    public Rigidbody2D body;

    // Update is called once per frame
    void Update()
    {
        posX = Input.GetAxis("Horizontal");
        posY = Input.GetAxis("Vertical");

        body.velocity = new Vector2(posX * speed, posY * speed);
    }
}
