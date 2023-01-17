using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuSceneChange : MonoBehaviour
{
    AudioSource buttonPress;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Maingamebutton()
    {
        //SceneManager.LoadScene("");
        buttonPress.Play();
    }

    public void Settingsbutton()
    {
        SceneManager.LoadScene("SettingsScreen");
        buttonPress.Play();
    }

    public void Creditsbutton()
    {
        SceneManager.LoadScene("CreditsScreen");
        buttonPress.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
