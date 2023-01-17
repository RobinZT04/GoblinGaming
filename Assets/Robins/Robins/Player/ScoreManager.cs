using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public static float score;

    [SerializeField]
    Text scoreTXT;
    public static int kills;

    public int limit;

    public AudioSource elevatorSource;
    public AudioClip elvatorClip;
    public AudioClip elevatorPling;

    public GameObject arrowEnd;

    public GameObject elevatorDoor;

    bool played = true;
    // Update is called once per frame

    private void Start()
    {
        kills = 0;
    }
    void Update()
    {

        if(limit == kills) //Robin
        {
            print("Elevator Open");
            
            if (played)
            {
                elevatorSource.PlayOneShot(elevatorPling, 1);
                played = false;
            }
            if(!elevatorSource.isPlaying)
            elevatorSource.PlayOneShot(elvatorClip, 0.3f);
            arrowEnd.SetActive(true);
            elevatorDoor.SetActive(false);
        }

        scoreTXT.text = score.ToString(); //Robin
    }
}
