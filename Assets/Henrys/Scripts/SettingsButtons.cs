using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsButtons : MonoBehaviour
{
    // Gör att man går tillbaks till main menyn när man klickar på knappen -Henry
    public void BackToMenuFromSettings()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Gör att skärmen byts till fullscreen när man klickar på knappen -Henry
    public void Fullscreen()
    {
        Screen.fullScreen = true;
    }

    // Samma som ovan fast windowed istället -Henry
    public void Windowed()
    {
        Screen.fullScreen = false;
    }

    // Trollfunktion som stänger av spelet när man tror att man rapporterar en bug :D -Henry
    public void BugReport()
    {
        Invoke("BugReport2", 0.5f);
    }
    public void BugReport2()
    {
        Application.Quit();
    }
}
