using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsButton : MonoBehaviour
{
    // G�r att man g�r tillbaka till main menyn n�r man klickar p� knappen -Henry
    public void BackToMenuFromCredits()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
