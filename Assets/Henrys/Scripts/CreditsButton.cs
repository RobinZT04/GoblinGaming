using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsButton : MonoBehaviour
{
    // Gör att man går tillbaka till main menyn när man klickar på knappen -Henry
    public void BackToMenuFromCredits()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
