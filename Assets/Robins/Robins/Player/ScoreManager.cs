using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public Animator elevatorAnim;

    bool played = true;

    public DialogueTrigger dTrigger;

    public Text deathCounter;
    public static int deathCount;
    // Update is called once per frame

    private void Start()
    {
        kills = 0;
        Invoke("Dialog", 1);
    }
        
    void Dialog()
    {
        dTrigger.TriggerDialogue();

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
        if(limit == kills) //Robin
        {
            print("Elevator Open");
            
            if (played)
            {
                elevatorSource.PlayOneShot(elevatorPling, 1);
                played = false;
            }
            elevatorAnim.SetBool("Open", true);
            if(!elevatorSource.isPlaying)
            elevatorSource.PlayOneShot(elvatorClip, 0.3f);
            arrowEnd.SetActive(true);
            elevatorDoor.SetActive(false);
        }

        scoreTXT.text = score.ToString(); //Robin
        deathCounter.text = "x" + deathCount.ToString();
    }
}
