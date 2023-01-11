using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public static float score;

    [SerializeField]
    Text scoreTXT;

    // Update is called once per frame
    void Update()
    {
        scoreTXT.text = score.ToString();
    }
}
