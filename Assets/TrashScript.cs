using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashScript : MonoBehaviour
{
    [SerializeField]
    Sprite[] trashSprites;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = trashSprites[Random.Range(0, trashSprites.Length)]; //Random sprite vid instatiation
    }

}
