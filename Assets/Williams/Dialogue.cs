using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
//All information som beh�vs, allts� namnen, bilderna, texterna samt ifall scenen ska bytas d�refter -William
public class Dialogue
{
    public bool changeScene;
    public string[] names;
    public Sprite[] sprites;
    public AudioClip[] audioClips;

    [TextArea(3, 10)]
    public string[] sentences;
}
