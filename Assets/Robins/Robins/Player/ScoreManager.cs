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

    // Update is called once per frame
    void Update()
    {

        if(limit == kills) //Robin
        {
            print("Elevator Open");
        }

        scoreTXT.text = score.ToString(); //Robin
    }
}
