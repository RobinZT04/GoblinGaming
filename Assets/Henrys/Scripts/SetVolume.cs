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
    private void Start()
    {
        mixer.GetFloat("MusicVol", out temp);
      //  volumeSlider.value = ( Mathf. temp / 20);
    }

    // När man ändrar valuen av volym slidern ändras också volymen -Henry
    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat("MusicVol", Mathf.Log10 (sliderValue) * 20);
    }
}
