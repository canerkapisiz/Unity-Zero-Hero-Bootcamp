using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundsManager : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private AudioSource[] kaynak;
    int kaynakRandom;

    void Start()
    {
        if (!PlayerPrefs.HasKey("ortamSes"))
        {
            PlayerPrefs.SetFloat("ortamSes", 0.5f);
        }
        volumeSlider.value = PlayerPrefs.GetFloat("ortamSes");
        kaynakRandom = Random.Range(0, kaynak.Length);
        kaynak[kaynakRandom].Play();
        kaynak[kaynakRandom].volume = PlayerPrefs.GetFloat("ortamSes");
    }

    void Update()
    {
        if (volumeSlider.value != PlayerPrefs.GetFloat("ortamSes"))
        {
            PlayerPrefs.SetFloat("ortamSes", volumeSlider.value);
            VolumeAyarlama();
        }
    }

    void VolumeAyarlama()
    {
        kaynak[kaynakRandom].volume = PlayerPrefs.GetFloat("ortamSes");
    }
}
