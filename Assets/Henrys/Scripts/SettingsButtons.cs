using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsButtons : MonoBehaviour
{
    public void BackToMenuFromSettings()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Fullscreen()
    {
        Screen.fullScreen = true;
    }

    public void Windowed()
    {
        Screen.fullScreen = false;
    }

    public void BugReport()
    {
        Application.Quit();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
