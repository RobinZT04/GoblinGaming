using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
//All information som beh�vs, allts� namnet, bilden, och texten -William
public class Dialogue
{
    public string name;
    public Sprite image;

    [TextArea(3, 10)]
    public string[] sentences;
}
