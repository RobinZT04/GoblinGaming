using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsButtons : MonoBehaviour
{
    // G�r att man g�r tillbaks till main menyn n�r man klickar p� knappen -Henry
    public void BackToMenuFromSettings()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // G�r att sk�rmen byts till fullscreen n�r man klickar p� knappen -Henry
    public void Fullscreen()
    {
        Screen.fullScreen = true;
    }

    // Samma som ovan fast windowed ist�llet -Henry
    public void Windowed()
    {
        Screen.fullScreen = false;
    }

    // Trollfunktion som st�nger av spelet n�r man tror att man rapporterar en bug :D -Henry
    public void BugReport()
    {
        Invoke("BugReport2", 0.5f);
    }
    public void BugReport2()
    {
        Application.Quit();
    }
}
