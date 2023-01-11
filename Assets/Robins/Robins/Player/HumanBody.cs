using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanBody : MonoBehaviour
{
    [SerializeField]
    Transform body;

    GameObject player;
    // Start is called before the first frame update
    void Update()
    {
        transform.position = body.transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    public void Head()
    {
        Vector2 direction = new Vector2 //Vector2 direction �r new vector2
         (
         player.transform.position.x - transform.position.x, //tar musens positon.x - transform.position.x
         player.transform.position.y - transform.position.y //tar musens positon.y - transform.position.y
         );

        transform.up = direction; //transform.up �r nu likamed direction
    }
}
