using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private TMP_Text volumeTextValue = null;

    private void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("masterVolume");
        volumeTextValue.text = PlayerPrefs.GetFloat("masterVolume").ToString("0.0");
    }

    void Update()
    {
    }

    public void SliderDeger()
    {
        //ileti.SendMessage("gameManagerDeger", volumeSlider.value);
        AudioManager.instance.audioSource.volume = volumeSlider.value;
        volumeTextValue.text = volumeSlider.value.ToString("0.0");
        
    }

    public void VolumeReset()
    {
        // ileti.SendMessage("gameManagerDeger", 0);
        AudioManager.instance.audioSource.volume = 1f;
        volumeSlider.value = 1;
            volumeTextValue.text = "1.0";
    }
}
