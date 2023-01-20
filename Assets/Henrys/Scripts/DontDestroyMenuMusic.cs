using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyMenuMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Om scenen är Level1 "förstörs" bakgrundsmusiken -Henry
        if (SceneManager.GetActiveScene().name == "OpeningScene")
        {
            Destroy(gameObject);
        }
        // annars fortsätter den spela -Henry
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
