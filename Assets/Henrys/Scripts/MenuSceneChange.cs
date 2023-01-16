using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuSceneChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Maingamebutton()
    {
        //SceneManager.LoadScene("");
    }

    public void Settingsbutton()
    {
        SceneManager.LoadScene("SettingsScreen");
    }

    public void Creditsbutton()
    {
        SceneManager.LoadScene("CreditsScreen");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
