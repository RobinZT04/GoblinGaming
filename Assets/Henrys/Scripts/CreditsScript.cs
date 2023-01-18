using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsScript : MonoBehaviour
{
    // Referens till textens rigidbody (g�r att den kan r�ra sig) samt SerializeField f�r att den ska synas i inspektorn -Henry
    [SerializeField]
    Rigidbody2D textMove;

    // Start is called before the first frame update
    void Start()
    {
        // Flyttar texten upp�t -Henry
        textMove.velocity = (new Vector2(0, 1250));
    }

    // N�r Texten tr�ffar en osynlig trigger stannar den -Henry
    private void OnTriggerEnter2D(Collider2D collision)
    {
        textMove.velocity = (new Vector2(0, 0));
    }
}
