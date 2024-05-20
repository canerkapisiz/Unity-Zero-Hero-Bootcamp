using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    [Header("Volume Settings")]
    [SerializeField] private TMP_Text volumeTextValue = null;
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private float defaultVolume = 1.0f;

    public static AudioManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        PlayerPrefs.SetFloat("masterVolume", 1f);
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volumeSlider.value;
        volumeTextValue.text = volumeSlider.value.ToString("0.0");
    }

    public void Volumeapply()
    {
        PlayerPrefs.SetFloat("masterVolume", audioSource.volume);
    }

    public void ResetButton(string MenuType)
    {
        if (MenuType == "Audio")
        {
            audioSource.volume = defaultVolume;
            volumeSlider.value = defaultVolume;
            volumeTextValue.text = defaultVolume.ToString("0.0");
        }
    }
}
