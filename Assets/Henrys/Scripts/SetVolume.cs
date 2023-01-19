using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    // Referens till mixern -Henry
    public AudioMixer mixer;
    [SerializeField]
    Slider volumeSlider;
    float temp;
    private void Awake()
    {
        mixer.GetFloat("MusicVol", out temp);
        //print(temp);
        volumeSlider.value = ( Mathf.Pow(10, temp) / 20); //H�r vill vi g�ra motsatsen av det vi gjorde p� rad 23
        //print("Eriks matte " + (Mathf.Pow(10, temp) / 20));
    }

    // N�r man �ndrar valuen av volym slidern �ndras ocks� volymen -Henry
    public void SetLevel(float sliderValue)
    {
        //print("slider value " + sliderValue);
        mixer.SetFloat("MusicVol", Mathf.Log10 (sliderValue) * 20); //Tar in ett v�rde (sliderValue) och �ndrar den -Henry/Tobias
    }
}
