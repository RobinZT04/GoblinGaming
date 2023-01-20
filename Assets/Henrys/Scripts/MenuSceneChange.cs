using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuSceneChange : MonoBehaviour
{
    // V�ntar 0,5 sekunder innan scenen byts (f�r att knappens ljud ska hinna spelas) -Henry
    public void Maingamebutton()
    {
        Invoke("Maingamebutton2", 0.5f);
    }
    // N�r man klickar p� knappen byter den scen till sj�lva spelet -Henry
    public void Maingamebutton2()
    {
        SceneManager.LoadScene("OpeningScene");
    }

    // Samma som ovan (fast annan scen) -Henry
    public void Settingsbutton()
    {
        Invoke("Settingsbutton2", 0.5f);
    }
    public void Settingsbutton2()
    {
        SceneManager.LoadScene("SettingsScreen");
    }

    //         - || -
    public void Creditsbutton()
    {
        Invoke("Creditsbutton2", 0.5f);
    }
    public void Creditsbutton2()
    {
        SceneManager.LoadScene("CreditsScreen");
    }
}
