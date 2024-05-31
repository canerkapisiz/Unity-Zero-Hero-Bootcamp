using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherSoundsManager : MonoBehaviour
{
    [SerializeField] private AudioSource[] kaynak;
    int kaynakRandom;

    void Start()
    {
        kaynakRandom = Random.Range(0, kaynak.Length);
        kaynak[kaynakRandom].Play();
        kaynak[kaynakRandom].volume = PlayerPrefs.GetFloat("ortamSes");
    }
}
