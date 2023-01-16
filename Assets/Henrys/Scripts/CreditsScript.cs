using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsScript : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D textMove;

    // Start is called before the first frame update
    void Start()
    {
        // Flyttar texten uppåt -Henry
        textMove.velocity = (new Vector2(0, 1250));
    }

    // När Texten träffar en osynlig trigger stannar dem -Henry
    private void OnTriggerEnter2D(Collider2D collision)
    {
        textMove.velocity = (new Vector2(0, 0));
    }
}
