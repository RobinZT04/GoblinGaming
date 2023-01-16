using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public static bool canRotate;
    private void Awake()
    {
        canRotate = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (!PlayerAttack.playerDead)
        {
            if (canRotate)
                Rotate();
        }
    }

    void Rotate() //Roterar spelaren mot musen //Robin
    {
        Vector3 mousePosition = Input.mousePosition; //vector3 mouseposition blir musens positon //Robin

        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition); //sätter mousepositonen sedd fr�n kameran //Robin

        Vector2 direction = new Vector2 //Vector2 direction är new vector2 //Robin
        (
        mousePosition.x - transform.position.x, //tar musens positon.x - transform.position.x //Robin
        mousePosition.y - transform.position.y //tar musens positon.y - transform.position.y //Robin
        );

        transform.up = direction; //transform.up ör nu direction //Robin
    }
}
