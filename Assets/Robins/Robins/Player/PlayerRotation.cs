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
        if(canRotate)
        Rotate();
    }

    void Rotate()
    {
        Vector3 mousePosition = Input.mousePosition; //vector3 mouseposition blir musens positon

        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition); //sätter mousepositonen sedd fr�n kameran

        Vector2 direction = new Vector2 //Vector2 direction är new vector2
        (
        mousePosition.x - transform.position.x, //tar musens positon.x - transform.position.x
        mousePosition.y - transform.position.y //tar musens positon.y - transform.position.y
        );

        transform.up = direction; //transform.up ör nu likamed direction
    }
}
