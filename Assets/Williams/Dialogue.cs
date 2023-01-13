using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
//All information som behövs, alltså namnen, bilderna, och texterna -William
public class Dialogue
{
    public string[] names;
    public Sprite[] sprites;
    public AudioClip[] audioClips;

    [TextArea(3, 10)]
    public string[] sentences;
}
